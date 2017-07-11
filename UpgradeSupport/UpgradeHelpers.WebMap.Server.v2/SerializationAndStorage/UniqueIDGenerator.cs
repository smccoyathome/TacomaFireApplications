using System;
using System.Runtime.CompilerServices;
using System.Threading;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{
	/// <summary>
	///     NOTE: probable should use state stateManager not session because
	///     storage mechanism could not be the storage
	/// </summary>
	public class UniqueIDGenerator : IStateObject, IInternalData, IUniqueIDGenerator
	{
		internal const string UniqueIdGeneratorCacheId = "@@UniqueIDGenerator";
		internal const char UniqueIdSeparator = '#';
		internal const string UniqueIdSeparatorStr = "#";
        internal const string TEMPPrefix = "$";
		internal const char TEMPPrefixChar = '$';
		internal const char SINGLETONPrefix = '&';
		internal const string EVENTPrefix = "%";
		private const string PromisesPREFIX = "^";
		private const string LISTPrefix = "Z";
        private const char LISTPrefixChar = 'Z';
		internal const string REFERENCEPrefix = "->";
		private const string MODELPrefix = "M";
        private const char MODELPrefixChar = 'M';
		internal const string REFTABLEPrefix = "^Rt";
		private const string SHAREDPrefix = ">";
        private const char SHAREDPrefixChar = '>';

		private const string ORPHANPrefix = "X";


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsAllBranchesAttached(string uniqueId)
        {
            return uniqueId != null && uniqueId.LastIndexOf(UniqueIDGenerator.TEMPPrefixChar) == -1;
        }

        public static bool IsListItem(string uniqueId)
        {
            return uniqueId != null && uniqueId.Length > 0 && uniqueId[0] == 'K' && uniqueId[1] == 'I';
        }

        public static string GetSinglentonUniqueId(System.Type t)
		{
			return ">" + t.FullName;
		}
		public UniqueIDGenerator()
		{
			_seed = 1;
			_tempseed = 1;
			UniqueID = UniqueIdGeneratorCacheId;
		}

		public int _seed;
		public int Seed { get { return _seed; } set { _seed = value; } }

		public int _tempseed;
		public int TempSeed { get { return _tempseed; } set { _tempseed = value; } }

		#region IStateObject Members

		public string UniqueID { get; set; }

		#endregion


		/// <summary>
		///     Returns a new unique ID which can someone be related to the object parent
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		public static string GetRelativeUniqueID(IStateObject parent, string id)
		{
			return id + UniqueIDGenerator.UniqueIdSeparatorStr + parent.UniqueID;
		}



        public static string GetEventRelativeUniqueID(IStateObject parent, string id)
        {
            return EVENTPrefix +  id + UniqueIDGenerator.UniqueIdSeparatorStr + parent.UniqueID;
        }


        public string GetRelativeUniqueID(IStateObject parent)
		{
			return GetRelativeUniqueID(parent, GetUniqueID());
		}

		public string GetOrphanUniqueID()
		{
			return ORPHANPrefix + GetUniqueID();
		}
		public string GetAdoptionRelativeUniqueID(IStateObject parent)
 		{
			return GetRelativeUniqueID(parent, ORPHANPrefix + GetUniqueID());
 		}

		public string GetFamilyUniqueID()
		{
			return "^F" + GetUniqueID();
		}

		public string GetBuilderUniqueID()
		{
			return "^B" + GetUniqueID();
		}

		/// <summary>
		///     Returns a new unique ID
		/// </summary>
		/// <returns></returns>
		public string GetUniqueID()
		{
			int nextValue = GetNextSeed();
            string res = nextValue.ToBase48ToString(); //Base62.Encode(nextValue);
			return res;
		}

		/// <summary>
		///     Returns a new unique ID
		/// </summary>
		/// <returns></returns>
		public string GetTempUniqueID()
		{
			int nextValue = GetNextTempSeed();
            string res = nextValue.ToBase48ToString(); //Base62.Encode(nextValue);
			return res;
		}

		/// <summary>
		///     Returns a new unique ID
		/// </summary>
		/// <returns></returns>
		public string GetPromiseUniqueID()
		{
			int nextValue = GetNextSeed();
            string res = PromisesPREFIX + nextValue.ToBase48ToString(); //Base62.Encode(nextValue);
			return res;
		}


		private int GetNextSeed()
		{
			return Interlocked.Increment(ref this._seed);
		}

		private int GetNextTempSeed()
		{
			return Interlocked.Increment(ref this._tempseed);
		}

		
        internal static string ReplaceParent(string uniqueID, string oldAttachedParent, string newDetacchedParent)
        {
            return uniqueID.Replace(oldAttachedParent, newDetacchedParent);
        }

		object tempseedLock = new object();


        /// <summary>
        /// Returns an ID that marks the object as being temporary.
        /// A global static seed is shared between all session because those IDs do not persist, it should not matter.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal string GetUniqueIDForTemporaryObject()
		{
			return UniqueIDGenerator.TEMPPrefix + GetTempUniqueID();
		}


        /// <summary>
        /// Builds a pointer unique id from another unique id.
        /// </summary>
        /// <param name="uniqueId">The base element to build a unique id from.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetPointerRelativeUniqueID(IStateObject parent, string id)
        {
            return REFERENCEPrefix +  id + UniqueIDGenerator.UniqueIdSeparatorStr + parent.UniqueID;
        }

        public static string GetReferenceTableRelativeUniqueID(string parentUniqueID)
        {
            return REFTABLEPrefix + UniqueIDGenerator.UniqueIdSeparatorStr + parentUniqueID;
        }

        
        internal string GetReferenceArrayRelativeUniqueID(IStateObject _parent)
        {
            return LISTPrefix + GetUniqueID() + UniqueIDGenerator.UniqueIdSeparatorStr + _parent.UniqueID;
        }

		internal static string GetTopLevelUniqueID(string uniqueID)
		{
			var uid = uniqueID;
			var indexOfSeparator = uniqueID.LastIndexOf(UniqueIdSeparator);
			if (indexOfSeparator != -1)
				uid = uniqueID.Substring(indexOfSeparator + 1);
			return uid;
		}

        /// <summary>
		/// Indicates whether the given unique id is a state pointer one.
		/// </summary>
		/// <param name="uniqueId"></param>
		/// <returns></returns>
		internal static bool IsPointer(string uniqueId)
        {
            return uniqueId.Length > 2 && uniqueId[0] == '-' && uniqueId[1] == '>';
        }
        /// <summary>
		/// Indicates whether the given unique id is a state pointer that points a Page
		/// </summary>
		/// <param name="uniqueId"></param>
		/// <returns></returns>
		internal static bool IsPointerPage(string uniqueId)
        {
            return uniqueId.Length > 4 && uniqueId[0] == '-' && uniqueId[1] == '>' && uniqueId[2] == 'K' && uniqueId[3] == 'P';
        }

        /// <summary>
        /// Checks if the given UniqueID is a Page
        /// </summary>
        /// <param name="uniqueID"></param>
        /// <returns></returns>
        internal static bool IsPage(string uniqueID)
        {
            return (uniqueID != null && uniqueID.Length > 0 && uniqueID[0] == 'K' && uniqueID[1] == 'P');
        }
        /// <summary>
        /// Checks if the Root level object is a Model. 
        /// </summary>
        /// <param name="uniqueID"></param>
        /// <returns></returns>
        internal static bool IsRootModel(string uniqueID)
		{
            var topLevelUniqueID = GetTopLevelUniqueID(uniqueID);
            return (topLevelUniqueID!=null && topLevelUniqueID.Length > 0 && topLevelUniqueID[0] == MODELPrefixChar);
		}

		/// <summary>
		/// Checks if the Root level object is a Model. 
		/// </summary>
		/// <param name="uniqueID"></param>
		/// <returns></returns>
		internal static bool IsModel(string topLevelUniqueID)
		{
			return (topLevelUniqueID != null && topLevelUniqueID.Length > 0 && topLevelUniqueID[0] == MODELPrefixChar);
		}

		/// <summary>
		/// Checks if the Root level object is a Model. 
		/// </summary>
		/// <param name="uniqueID"></param>
		/// <returns></returns>
		internal static bool IsUnAttached(string topLevelUniqueID)
		{
			return (topLevelUniqueID != null && topLevelUniqueID.Length > 0 && topLevelUniqueID[0] == TEMPPrefixChar);
		}

		/// <summary>
		/// Checks if the Root level object is a Model. 
		/// </summary>
		/// <param name="uniqueID"></param>
		/// <returns></returns>
		internal static bool IsSurrogate(string topLevelUniqueID)
		{
			return (topLevelUniqueID != null && topLevelUniqueID.Length > 0 && topLevelUniqueID[0] == '!');
		}

		/// <summary>
		/// Checks if the Root level object is a Model. 
		/// </summary>
		/// <param name="uniqueID"></param>
		/// <returns></returns>
		internal static bool IsReferencesArrayUniqueID(string uniqueID)
		{
            return (uniqueID != null && uniqueID.Length > 0 && uniqueID[0] == LISTPrefixChar);
		}
		/// <summary>
		/// Checks if the TopLevel object is a Shared State.
		/// </summary>
		/// <param name="uniqueID"></param>
		/// <returns></returns>
		internal static bool IsRootSharedState(string uniqueID)
		{
            var topLevelUniqueID = GetTopLevelUniqueID(uniqueID);
            return (topLevelUniqueID!=null && topLevelUniqueID.Length > 0 && topLevelUniqueID[0] == SHAREDPrefixChar); 
		}

		/// <summary>
		/// Checks if the TopLevel object is a Shared State.
		/// </summary>
		/// <param name="uniqueID"></param>
		/// <returns></returns>
		internal static bool IsSharedState(string topLevelUniqueID)
		{
			return (topLevelUniqueID != null && topLevelUniqueID.Length > 0 && topLevelUniqueID[0] == SHAREDPrefixChar);
		}

		internal static bool IsRefencesTable(string uniqueId)
		{
			return uniqueId != null && uniqueId.Length > 0 && uniqueId[0] == '^';
		}
		internal string GetUniqueIDForModel()
		{
			return MODELPrefix + GetUniqueID();
		}

        public string GetPageUniqueID()
        {
            return "KP" + GetUniqueID();
        }

        public string GetPageItemUniqueID()
        {
            return "KI" + GetUniqueID();
        }
    }
}