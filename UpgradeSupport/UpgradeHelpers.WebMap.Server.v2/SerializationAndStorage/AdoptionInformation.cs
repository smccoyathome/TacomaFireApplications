using System;
using System.Collections.Generic;
using System.Linq;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.EventAggregator;
using UpgradeHelpers.WebMap.Server.Common;

namespace UpgradeHelpers.WebMap.Server
{
    /// <summary>
    /// 
    /// </summary>
    internal class AdoptionInformation
    {

        #region SurrogatesHolders

        private HashSet<StateObjectSurrogate> _orphanHolders;
        private void AddSurrogateHolder(StateObjectSurrogate value)
        {
            _orphanHolders.Add(value);
        }

        /// <summary>
        /// Sometimes while serializing a "DisplayClass" we might find fields that reference 
        /// IStateObjects.
        /// Promises are persisted using the Surrogates mechanism, and we also are aware that
        /// Surrogates are the last thing to be serialized. 
        /// Processes like adoption occur even before StateManager.Persist is started.
        /// When the value for these fields are serialized, it might happen that there are still "unattached"
        /// so they need to be adopted
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="value"></param>
        internal StateObjectSurrogate GetOrphanHolder(object instance, IStateObject value, string fieldName)
        {
            if (!StateManager.AllBranchesAttached(value.UniqueID))
            {
                var displayClassSurrogate = _stateManager.surrogateManager.GetSurrogateFor(instance, generateIfNotFound: false);
                if (displayClassSurrogate == null) throw new InvalidOperationException("A surrogate is needed");

                //Retrieve surrogate
                StateObjectSurrogate surrogate = (StateObjectSurrogate)_stateManager.surrogateManager.GetSurrogateFor(value, generateIfNotFound: true);
                if (surrogate == null) throw new Exception("Object must be instantiated/registered with resolve");
                //Add reference if needed
                _stateManager.surrogateManager.AddSurrogateReference(surrogate, displayClassSurrogate.UniqueID);
                AddSurrogateHolder(surrogate);
                return surrogate;
            }
            else
                return null;
        }

        /// <summary>
        /// The surrogates created as Holders of IStateObjects must be persisted.
        /// </summary>
        internal void HandleSurrogateHolders()
        {
            //First we need to go through the properties and Adopt any Unattached object.
            foreach (StateObjectSurrogate obj in _orphanHolders)
            {
                var surrogateToAdoptSurrogate = _stateManager.surrogateManager.GetSurrogateFirstReference(obj);
                var objValue = obj.Value as IStateObject;
                AdoptionInformation.StaticAdopt(surrogateToAdoptSurrogate, objValue);
                foreach (var dependant in _stateManager.GetDependentItemsInCache(objValue.UniqueID))
                {
                    var pointer = dependant.Value as StateObjectPointer;
                    //If the Target of the opinter is also Unattached.
                    if (pointer != null && !(pointer is UpgradeHelpers.WebMap.Server.StateObjectPointerReferenceSuperValue))
                        AdoptionInformation.StaticAdopt(pointer, pointer.Target);
                    StateManager.Current.StorageManager.SaveObject(dependant.Value);
                }
            }
            //Once all the adoptions accured then we can procceed and store those adopted values.
            foreach (StateObjectSurrogate obj in _orphanHolders)
            {
                var surrogateToAdoptSurrogate = _stateManager.surrogateManager.GetSurrogateFirstReference(obj);
                var objValue = obj.Value as IStateObject;
                StateManager.Current.StorageManager.SaveObject(objValue);
				foreach (var dependant in StateManager.Current.GetDependentItemsInCache(objValue.UniqueID))
                {
                    StateManager.Current.StorageManager.SaveObject(dependant.Value);
                }
            }
            _orphanHolders.Clear();
        }


        #endregion


        public AdoptionInformation(StateManager stateManager)
        {
            _stateManager = stateManager;
            _uniqueIdGenerator = _stateManager.UniqueIDGenerator;
            //Implementation of OrphanInfoEqualityComparer implies that there can't orphans with more that one possible parent
            _currentOrphans = new HashSet<OrphanInfoEntry>(new OrphanInfoEqualityComparer());
            _godparentsOrphansAssignment = new Dictionary<IStateObject, OrphanInfoEntry>(ComparerByReference.CommonInstance);
            _orphanHolders = new HashSet<StateObjectSurrogate>();
        }

        private class OrphanInfoEntry
        {
            public readonly IStateObject Parent;
            public readonly IStateObject Godparent;
            public readonly IStateObject Orphan;

            public OrphanInfoEntry(IStateObject parent, IStateObject orphan, IStateObject godparent = null)
            {
                Parent = parent;
                Godparent = godparent;
                Orphan = orphan;
            }
        }

        private HashSet<OrphanInfoEntry> _currentOrphans;

        /// <summary>
        /// This Dictionary is maintained only during the duration of the Request
        /// Some orphans need a godFather in order to determine levels of dependency.
        /// We will use this godFather to sort the orphans to avoid orphans that have 
        /// an possible orphan parent and be pocessed before his parent
        /// </summary>
        private Dictionary<IStateObject, OrphanInfoEntry> _godparentsOrphansAssignment;

        private class OrphanComparer : IComparer<OrphanInfoEntry>
        {
            public int Compare(OrphanInfoEntry x, OrphanInfoEntry y)
            {
                var xUid = x.Parent.UniqueID;
                var yUid = y.Parent.UniqueID;

                if (StateManager.IsAttached(x.Parent))
                {
                    if (StateManager.IsAttached(y.Parent))
                    {
                        if (x.Godparent == null && y.Godparent == null)
                        {
                            if (xUid.Length > yUid.Length)
                                return 1;
                            if (xUid.Length < yUid.Length)
                                return -1;
                            return 0;
                        }
                        if (x.Godparent == null)
                            return -1;
                        if (y.Godparent == null)
                            return 1;

                        if (x.Godparent.UniqueID.Length > y.Godparent.UniqueID.Length)
                            return 1;
                        if (x.Godparent.UniqueID.Length < y.Godparent.UniqueID.Length)
                            return -1;
                        return 0;
                    }
                    return -1;
                }

                if (!StateManager.IsAttached(y.Parent))
                {
                    if (x.Godparent == null)
                        return 1;
                    if (y.Godparent == null)
                        return -1;

                    if (x.Godparent.UniqueID.Length > y.Godparent.UniqueID.Length)
                        return 1;
                    if (x.Godparent.UniqueID.Length < y.Godparent.UniqueID.Length)
                        return -1;
                    return 0;
                }
                return 1;
            }
        }

        private class OrphanInfoEqualityComparer : EqualityComparer<OrphanInfoEntry>
        {
            public override bool Equals(OrphanInfoEntry b1, OrphanInfoEntry b2)
            {
                return ReferenceEquals(b1.Orphan, b2.Orphan);

            }

            public override int GetHashCode(OrphanInfoEntry obj)
            {
                if (obj != null) return System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(obj.Orphan);
                throw new ArgumentNullException("obj", "The type of obj is an OrphanInfoEntry type and obj is null");
            }
        }

        private IOrderedEnumerable<OrphanInfoEntry> GetSortedOrphans()
        {
            return _currentOrphans.OrderBy(obj => obj, new OrphanComparer());
        }
        static Dummy dummy = new Dummy();
        class Dummy : IStateObject
        {
            public string UniqueID { get { return "Dummy"; } set { } }
        }
        class OrphanCandidatesInfo
        {

            /// <summary>
            /// Maps a parent to a dictionary of godparents => orphans
            /// </summary>
            internal Dictionary<IStateObject, Dictionary<IStateObject, IStateObject>> parentToGodParentsAndOrphans = new Dictionary<IStateObject, Dictionary<IStateObject, IStateObject>>(ComparerByReference.CommonInstance);

            internal Dictionary<IStateObject, HashSet<IStateObject>> orphanToParentCandidates;
            int seed = 5000;
            public void RegisterPossibleOrphan(IStateObject parent, IStateObject obj, IStateObject godparent)
            {
                Dictionary<IStateObject, IStateObject> godParentDict;
                if (!parentToGodParentsAndOrphans.TryGetValue(parent, out godParentDict))
                {
                    godParentDict = new Dictionary<IStateObject, IStateObject>(ComparerByReference.CommonInstance);
                    parentToGodParentsAndOrphans.Add(parent, godParentDict);
                }
                if (godparent == null)
                {
                    godparent = new Dummy() { UniqueID = (seed++).ToString() };
                }
                IStateObject storedOrphan;
                if (godParentDict.TryGetValue(godparent, out storedOrphan))
                {
                    if (!Object.ReferenceEquals(storedOrphan, obj))
                    {
                        godParentDict[godparent] = obj;
                    }
                }
                else
                {
                    godParentDict.Add(godparent, obj);
                }
            }


        }

        class ParentList : IEnumerable<IStateObject>, IEnumerator<IStateObject>
        {
            IStateObject parent;
            HashSet<IStateObject> parentList;

            public ParentList(IStateObject firstParent)
            {
                parent = firstParent;
            }

            public void Add(IStateObject newparent)
            {
                if (parentList != null)
                    parentList.Add(newparent);
                parentList = new HashSet<IStateObject>(ComparerByReference.CommonInstance);
                parentList.Add(parent);
                parentList.Add(newparent);
            }



            public IEnumerator<IStateObject> GetEnumerator()
            {
                if (parentList != null)
                    return parentList.GetEnumerator();
                return this;
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                if (parentList != null)
                    return parentList.GetEnumerator();
                return this;
            }

            IStateObject current;
            IStateObject IEnumerator<IStateObject>.Current
            {
                get
                {
                    return current;
                }
            }

            void IDisposable.Dispose()
            {

            }

            object System.Collections.IEnumerator.Current
            {
                get { return current; }
            }

            bool System.Collections.IEnumerator.MoveNext()
            {
                if (current != null)
                {
                    current = parent;
                    return true;
                }
                return false;
            }

            void System.Collections.IEnumerator.Reset()
            {
                current = null;
            }
        }

        OrphanCandidatesInfo orphanInformationTables = new OrphanCandidatesInfo();


        /// <summary>
        /// Register parent object as candidate foster parent for obj
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="obj"></param>
        /// <param name="godparent"></param>
        public void RegisterPossibleOrphan(IStateObject parent, IStateObject obj, IStateObject godparent=null)
        {
            lock (orphanInformationTables)
            {
                orphanInformationTables.RegisterPossibleOrphan(parent, obj, godparent);
            }
        }

        private HashSet<object> _promotedOrphans;
        private StateManager _stateManager;
        private UniqueIDGenerator _uniqueIdGenerator;

        private void Adopt(IStateObject parent, IStateObject orphan)
        {
            var referencesManager = _stateManager.ReferencesManager;
            //We will try to adopt the parent of an object if it has references, thats why first we need to calculate the parents with References.
            var orphansStack = new List<IStateObject>();
            //Candidates Stack.
            var candidatesStack = new List<IStateObject>();
            if (!StateManager.AllBranchesAttached(orphan))
            {
                //Let's try to calculate the posible parent of the orphan.
                var orphanCandidate = referencesManager.GetCandidateForAdoption(orphan,isHandlingOrphans:true);
                var isOphanCandidateAGoodCandidate = false;
                var isParentAGoodCandidate = false;
                if (orphanCandidate is IViewModel || orphanCandidate is IDependentViewModel)    isOphanCandidateAGoodCandidate = true;
                if (parent is IViewModel || parent is IDependentViewModel)  isParentAGoodCandidate = true;
                //The first and maybe the only element in the Stack is the Orphan, but
                //only if has a valid adoption candidate.
                if (orphanCandidate != null)
                {
                    orphansStack.Add(orphan);
                    //We will always prefer the candidate coming from the ReferencesManager
                    if (isOphanCandidateAGoodCandidate)
                        candidatesStack.Add(orphanCandidate);
                    //If neither both possible candidates is not a good candidates, we will also prefer the one coming from the references manager.
                    else if (!isParentAGoodCandidate && !isOphanCandidateAGoodCandidate)
                        candidatesStack.Add(orphanCandidate);
                    //This is the lowest preference 
                    else candidatesStack.Add(parent);
                }
                else
                //The adoption won't continue because the orphan doesn't have any valid candidate for adoption.
                {
                    ProcessAdoption(parent, orphan);
                    return;
                }
                IStateObject orphanParent;
                var orphanParentIterator = orphanParent = _stateManager.GetParentEx(orphan);
				HashSet<IStateObject> visitedParents = new HashSet<IStateObject>();
				//Cyclyc referernces are causing infinite loops.
				while (orphanParentIterator != null && !visitedParents.Contains(orphanParentIterator))
                {
                    //If the parent has References, then we add it to the orphans Stack.
                    if (referencesManager.HasReferences(orphanParentIterator))
                    {
                        var parentCandidate = referencesManager.GetCandidateForAdoption(orphanParentIterator, isHandlingOrphans: true);
                        if (parentCandidate != null)
                        {
                            orphansStack.Add(orphanParentIterator);
                            candidatesStack.Add(parentCandidate);
                        }
                    }
					visitedParents.Add(orphanParentIterator);
                    orphanParentIterator = _stateManager.GetParentEx(orphanParentIterator);
                }
                //From the candidates in the Tree let's get the best one.
                IStateObject currCandidate = candidatesStack[candidatesStack.Count - 1];
                var orphanToAdopt = orphansStack[orphansStack.Count - 1];
         
                ProcessAdoption(currCandidate, orphanToAdopt);
            }
        }

        private bool ProcessAdoption(IStateObject parent, IStateObject orphan)
        {
            if (!_promotedOrphans.Contains(orphan))
            {
                //Get relative id for orphan
				var orphanID = _uniqueIdGenerator.GetOrphanUniqueID();
				var newUniqueID = UniqueIDGenerator.GetRelativeUniqueID(parent, orphanID);
                _stateManager.PromoteObject(orphan, newUniqueID, inAdoption: true);
				LazyBehaviours.AddDependent(parent, orphanID);
                _promotedOrphans.Add(orphan);
                return true;
            }
            return false;
        }

        public static void StaticAdopt(IStateObject parent, IStateObject orphan)
        {
            var referencesManager = StateManager.Current.ReferencesManager;
            //We will try to adopt the parent of an object if it has references, thats why first we need to calculate the parents with References.
            var orphansStack = new List<IStateObject>();
            //Candidates Stack.
            var candidatesStack = new List<IStateObject>();
            if (!StateManager.AllBranchesAttached(orphan))
            {
                //Let's try to calculate the posible parent of the orphan.
                var orphanCandidate = referencesManager.GetCandidateForAdoption(orphan, isHandlingOrphans: true);
                var isOphanCandidateAGoodCandidate = false;
                var isParentAGoodCandidate = false;
                if (orphanCandidate is IViewModel || orphanCandidate is IDependentViewModel) isOphanCandidateAGoodCandidate = true;
                if (parent is IViewModel || parent is IDependentViewModel) isParentAGoodCandidate = true;
                //The first and maybe the only element in the Stack is the Orphan, but
                //only if has a valid adoption candidate.
                if (orphanCandidate != null)
                {
                    orphansStack.Add(orphan);
                    //We will always prefer the candidate coming from the ReferencesManager
                    if (isOphanCandidateAGoodCandidate)
                        candidatesStack.Add(orphanCandidate);
                    //If neither both possible candidates is not a good candidates, we will also prefer the one coming from the references manager.
                    else if (!isParentAGoodCandidate && !isOphanCandidateAGoodCandidate)
                        candidatesStack.Add(orphanCandidate);
                    //This is the lowest preference 
                    else candidatesStack.Add(parent);
                }
                else
                //The adoption won't continue because the orphan doesn't have any valid candidate for adoption.
                {
                    ProcessStaticAdoption(parent, orphan);
                    return;
                }

                var orphanParent = StateManager.Current.GetParentEx(orphan);
                while (orphanParent != null)
                {
                    //If the parent has References, then we add it to the orphans Stack.
                    if (referencesManager.HasReferences(orphanParent))
                    {
                        var parentCandidate = referencesManager.GetCandidateForAdoption(orphanParent);
                        if (parentCandidate != null)
                        {
                            orphansStack.Add(orphanParent);
                            candidatesStack.Add(parentCandidate);
                        }
                    }
                    orphanParent = StateManager.Current.GetParentEx(orphanParent);
                }
                //From the candidates in the Tree let's get the best one.
                IStateObject currCandidate = candidatesStack[candidatesStack.Count - 1];
                //for (int i = candidatesStack.Count - 1; i >= 0; i--)
                //{
                //    //Only if the paren't element is not visual let's try to find a better candidate.
                //    if (candidatesStack[i] is IViewModel || candidatesStack[i] is IDependentViewModel)
                //    {
                //        currCandidate = candidatesStack[i];
                //        break;
                //    }
                //}
                var orphanToAdopt = orphansStack[orphansStack.Count - 1];
                ProcessStaticAdoption(currCandidate, orphanToAdopt);
            }
        }

        private static void ProcessStaticAdoption(IStateObject parent, IStateObject orphan)
        {
            //if (child is still orphan)
            if (!StateManager.AllBranchesAttached(orphan))
            {
                //Get relative id for orphan
				var orphanID = StateManager.Current.UniqueIDGenerator.GetOrphanUniqueID();
				var newUniqueID = UniqueIDGenerator.GetRelativeUniqueID(parent, orphanID);
				LazyBehaviours.AddDependent(parent, orphanID);
                StateManager.Current.SwitchOrPromoteObject(orphan, newUniqueID, inAdoption: true);
            }
        }

        public IList<IStateObject[]> ExtractOrphansWithQualifiedParents()
        {
            List<IStateObject[]> result = new List<IStateObject[]>();
            foreach (var orphan in orphanInformationTables.orphanToParentCandidates)
            {
                if (orphan.Key is IDependentViewModel)
                {
                    var parentList = orphan.Value;
                    IStateObject firstNonVisualParentCandidate = null; ;
                    IStateObject firstVisualParentCandidate = null;
                    foreach (var parent in parentList)
                    {
                        if (StateManager.AllBranchesAttached(parent))
                        {
                            if (parent is IModel || parent is IDependentModel || parent is IStateObjectSurrogate)
                            {
                                firstNonVisualParentCandidate = parent;
                                continue;
                            }
                            if (parent is IViewModel || parent is IDependentViewModel)
                            {
                                firstVisualParentCandidate = parent;
                                break;
                            }
                        }
                    }
                    if (firstVisualParentCandidate != null)
                    {
                        result.Add(new[] { orphan.Key, firstVisualParentCandidate });
                    }
                    else if (firstNonVisualParentCandidate != null)
                    {
                        result.Add(new[] { orphan.Key, firstNonVisualParentCandidate });
                    }
                }
                else
                {
                    var parentList = orphan.Value;
                    foreach (var parent in parentList)
                    {
                        if (StateManager.AllBranchesAttached(parent))
                        {
                            result.Add(new[] { orphan.Key, parent });
                            break;
                        }
                    }
                }
            }
            foreach (var pairs in result)
            {
                orphanInformationTables.orphanToParentCandidates.Remove(pairs[0]);
            }
            if (result.Count > 0)
            {
                //We sort this list to make sure that children adoptions occur before parent adoptions
                result.Sort((x, y) => { 
					if (x==null)
						return -1;
					if (y==null)
						return 1;
					return CompareOrphans(x[0], y[0]); 
				});
            }
            return result;
        }

        public static int CompareOrphans(IStateObject orphan1, IStateObject orphan2)
        {
            if (orphan1.UniqueID == null)
            {
                return -1;
            }
            if (orphan2.UniqueID == null)
            {
                return 1;
            }
            if (orphan1.UniqueID.Length > orphan2.UniqueID.Length)
            {
                return 1;
            }
            else if (orphan2.UniqueID.Length > orphan1.UniqueID.Length)
            {
                return -1;
            }
            else 
                return 0;
            
        }

        public void HandleOrphansEx()
        {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            //We will load this infromation
            var orphanToParentCandidates = orphanInformationTables.orphanToParentCandidates = new Dictionary<IStateObject, HashSet<IStateObject>>(ComparerByReference.CommonInstance);

            //We do not care abour godparents so we will just make a list of orphans an possible parents
            foreach (var parentToGodParentInfo in orphanInformationTables.parentToGodParentsAndOrphans)
            {
                var parent = parentToGodParentInfo.Key;
                //We do not care for godparents we only care about orphans
                foreach (var pairGodParentAndOrphan in parentToGodParentInfo.Value)
                {
                    var orphan = pairGodParentAndOrphan.Value;
                    if (!StateManager.AllBranchesAttached(orphan))
                    {
                        HashSet<IStateObject> parentList;
                        if (!orphanToParentCandidates.TryGetValue(orphan, out parentList))
                        {
                            orphanToParentCandidates[orphan] = parentList = new HashSet<IStateObject>(ComparerByReference.CommonInstance);//new ParentList(parent);
                        }
                        parentList.Add(parent);
                    }
                }
            }

            _promotedOrphans = new HashSet<object>(ComparerByReference.CommonInstance);
            int adoptedOrphans = 0;
            do
            {
                var happyAdoptions = ExtractOrphansWithQualifiedParents();
                adoptedOrphans = happyAdoptions.Count;
                foreach (var happyAdoption in happyAdoptions)
                {
                    Adopt(happyAdoption[1], happyAdoption[0]);
                }
            }
            while (adoptedOrphans > 0 && orphanInformationTables.orphanToParentCandidates.Count > 0);
            //Any orphan added to the wating room are processed.
            TraceUtil.WriteLine("------->>>>> Unadopted orpahns: " + orphanInformationTables.orphanToParentCandidates.Count);
            sw.Stop();
            TraceUtil.WriteLine("Adoption time " + sw.ElapsedMilliseconds);
        }


        //private int AdoptToAttachedParent(IOrderedEnumerable<OrphanInfoEntry> sortedOrphans)
        //{
        //    var adoptedOrphants = 0;
        //    var current = StateManager.Current;
        //    var tempCacheValues = current._tempcache.Values;
        //    var cacheValues = current._cache.Values;

        //    foreach (var orphanInfo in sortedOrphans)
        //    {
        //        //Is parent attached?
        //        //if (!tempCacheValues.Contains(orphanInfo.Parent, new CustomComparer()))
        //        //{
        //        //	Adopt(orphanInfo.Parent, orphanInfo.Orphan);
        //        //	this._currentOrphans.Remove(orphanInfo);
        //        //	adoptedOrphants++;
        //        //}
        //        if (current._tempcache.GetIndexedKeyByValue(orphanInfo.Parent) == null)
        //        {
        //            Adopt(orphanInfo.Parent, orphanInfo.Orphan);
        //            _currentOrphans.Remove(orphanInfo);
        //            adoptedOrphants++;
        //        }
        //        //if (cacheValues.Contains(orphanInfo.Parent, new CustomComparer()))
        //        //{
        //        //	Adopt(orphanInfo.Parent, orphanInfo.Orphan);
        //        //	this._currentOrphans.Remove(orphanInfo);
        //        //	adoptedOrphants++;
        //        //}
        //    }

        //    return adoptedOrphants;
        //}


		internal void Dispose()
		{
			this._currentOrphans = null;
			this._godparentsOrphansAssignment = null;
			this._orphanHolders = null;
			this._promotedOrphans = null;
			this._stateManager = null;
			this._uniqueIdGenerator = null;
			this.orphanInformationTables = null;
		}
	}
}