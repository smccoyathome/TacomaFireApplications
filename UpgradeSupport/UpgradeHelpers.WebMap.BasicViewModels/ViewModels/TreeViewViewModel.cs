using System.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Text.RegularExpressions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server;

namespace UpgradeHelpers.BasicViewModels
{
	/// <summary>
	///   ViewModel for the elements of a TreeView
	/// </summary>
	public class TreeNodeViewModel : ControlViewModel, IIdentifiableCollectionItem, IInitializable, IInitializable<string>
	{

		[JsonProperty("@k")]
		public int k = 1;

		public virtual IList<TreeNodeViewModel> _items { get; set; }

		[StateManagement(StateManagementValues.None)]
		public IList<TreeNodeViewModel> Items { get { return _items; } }


		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
			Name = "";
			Text = "";
			ImageListPrefix = "";
			_items = ctx.Resolve<IList<TreeNodeViewModel>>();

		}

		private string _fullpath = "";
		public virtual bool Checked { get; set; }
		public string Key { get { return this.Name; } set { this.Name = value; } }
		public virtual int ImageIndex { get; set; }
		public virtual string ImageListPrefix { get; set; }
		public virtual bool IsSelected { get; set; }
		public virtual bool IsExpanded { get; set; }
		public virtual int Index { get; set; }
		public virtual bool IsVisible { get; set; }
		public virtual int SelectedImageIndex { get; set; }
		public virtual string ImageKey { get; set; }
		public virtual Font NodeFont { get; set; }
		public virtual int Level { get; set; }

		public void Set_ImageKey(string key)
		{
			ImageKey = key;
		}

		public string Get_ImageKey()
		{
			return ImageKey;
		}

		public void EnsureVisible()
		{
			IsExpanded = true;
			IsVisible = true;
		}

		public TreeNodeViewModel Add(TreeNodeViewModel node)
		{
			return Add(node.Name, node.Text, node.ImageIndex);
		}

		public TreeNodeViewModel Add(string text)
		{
			return Add("", text);
		}

		public TreeNodeViewModel Add(string name, string text, int imageIndex = -1)
		{
			var result = StaticContainer.Instance.Resolve<TreeNodeViewModel>();

			result.Name = name;
			result.Text = text;
			result.ImageIndex = imageIndex;
			result.ImageListPrefix = ImageListPrefix;
			result.Level = this.Level + 1;
			result.Index = this.GetNodeCount(false);
			if (this.Parent != null)
				result.IsVisible = this.Parent.IsExpanded;
			else
				result.IsVisible = this.IsExpanded;
			Items.Add(result);
			return result;
		}
		/*Note: ImageKey is not supported. Because the image resource are renamed after migration process*/
		public TreeNodeViewModel Add(string key, string text, string imageKey, string selectedImageKey)
		{
			var imageIndex = -1;
			var tree = GetTreeViewModel();
			if (tree != null &&
				tree.ImageList != null &&
				tree.ImageList.Images.ImagesKeys.TryGetValue(imageKey, out imageIndex))
			{
				return Add(key, text, imageIndex);
			}
			return Add(key, text);
		}

		public TreeNodeViewModel Add(string key, string text, int imageIndex, int selectedImageIndex)
		{
			return Add(key, text, imageIndex);
		}

		public TreeViewViewModel GetTreeViewModel()
		{
			return ((TreeViewViewModel)ViewManager.GetParent(ViewManager.GetParent(this)));
		}

		public string ImageUrl
		{
			get
			{
				if (ImageIndex == -1)
				{
					return null;
				}
				else
				{
					return "Resources/images/" + (ImageListPrefix ?? "") + ImageIndex + ".png";
				}
			}
			set { }
		}


		////////////////////////////////////
		///Calculated Properties
		///
		[StateManagement(StateManagementValues.None)]
		public virtual string FullPath
		{
			get
			{
				if (this.Parent == null)
					_fullpath = this.Text;
				else
					_fullpath = Parent.FullPath + "\\" + this.Text;

				return _fullpath;
			}

		}

		[StateManagement(StateManagementValues.None)]
		public virtual TreeNodeViewModel FirstNode
		{
			get
			{
				if (this.Items.Count > 0)
					return this.Items[0];
				else
					return null;
			}
			set { }

		}

		[StateManagement(StateManagementValues.None)]
		public virtual TreeNodeViewModel NextNode
		{
			get
			{
				var _parent = this.Parent;
				if (_parent != null)
				{
					if (Index + 1 < _parent.GetNodeCount(false))
					{
						return _parent.Items[Index + 1];
					}
					else
						return null;
				}
				else
				{
					var _rootParent = GetRootParent();
					if (_rootParent != null)
					{
						if (Index + 1 < _rootParent.Items.Count)
						{
							return _rootParent.Items[Index + 1];
						}
						else
							return null;
					}
					else return null;
				}

			}
		}

		[StateManagement(StateManagementValues.None)]
		public virtual TreeNodeViewModel PrevNode
		{
			get
			{
				var _parent = this.Parent;
				if (_parent != null)
				{
					var prevIndex = Index - 1;
					if (prevIndex >= 0 && prevIndex < _parent.GetNodeCount(false))
					{
						return _parent.Items[prevIndex];
					}
					else
						return null;
				}
				else
				{
					var _rootParent = GetRootParent();
					if (_rootParent != null)
					{
						var prevIndex = Index - 1;
						if (prevIndex >= 0 && prevIndex < _rootParent.Items.Count)
						{
							return _rootParent.Items[prevIndex];
						}
						else
							return null;
					}
					else return null;
				}
			}
		}

		[StateManagement(StateManagementValues.None)]
		public new TreeNodeViewModel Parent
		{
			get
			{
				try
				{
					var p = ViewManager.GetParent(this);
					if(p is WebMap.Server.IWebMapList)
					{
						return ((TreeNodeViewModel) ViewManager.GetParent(p));
					}else return (TreeNodeViewModel)p;
				}
				catch (InvalidCastException e)
				{ //NullCast means there is no Parent
					return null;
				}
			}

		}

		private TreeViewViewModel GetRootParent()
		{
			var parent = ViewManager.GetParent(this);
			if(parent is IWebMapList)
			{
				return ViewManager.GetParent(parent) as TreeViewViewModel;
			}else
			{
				return parent as TreeViewViewModel;
			}
				 
		}
		/// <summary>
		/// Gets The NextVisibleNode can be a child or a sibling
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public TreeNodeViewModel NextVisibleNode
		{
			get
			{
				return NextVisibleChild() ?? NextVisibleSibling();
			}
		}

		/// <summary>
		/// Gets The PrevVisibleNode can be a child or a sibling
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public TreeNodeViewModel PrevVisibleNode
		{
			get
			{
				var prevVisibleSibling = this.PrevVisibleSibling();
				if (prevVisibleSibling != null)
				{
					var prevChild = prevVisibleSibling.LastVisibleChild();
					if (prevChild != null)
						return prevChild;
					else
						return prevVisibleSibling;
				}
				else
					if (this.Parent != null)
					return this.Parent;
				return null;
			}
		}


		private TreeNodeViewModel NextVisibleChild()
		{
			for (int i = 0; i < this.Items.Count; i++)
			{
				var current = this.Items[i];
				if (current.IsVisible)
					return current;
				else
					this.Items[i].NextVisibleChild();
			}
			return null;
		}

		private TreeNodeViewModel NextVisibleSibling()
		{
			var _parent = this.Parent;
			if (_parent != null)
			{
				for (int i = this.Index + 1; i < _parent.Items.Count; i++)
				{
					var current = _parent.Items[i];
					if (current.IsVisible)
					{
						return current;
					}
				}
				return this.Parent.NextVisibleSibling();
			}
			else
			{
				var _rootParent = GetRootParent();
				if (_rootParent != null)
				{
					for (int i = this.Index; i < _rootParent.Items.Count; i++)
					{
						var current = _rootParent.Items[i];
						if (current.IsVisible)
						{
							return current;
						}
					}
					return null;
				}
				else return null;
			}

		}

		private TreeNodeViewModel PrevVisibleSibling()
		{
			var _parent = this.Parent;
			if (_parent != null)
			{
				TreeNodeViewModel result = null;
				for (int i = 0; i < _parent.Items.Count && i < this.Index; i++)
				{
					var current = _parent.Items[i];
					if (current.IsVisible)
					{
						result = current;
					}
				}
				if (result != null)
					return result;
				else
					return this.Parent.PrevVisibleSibling();
			}
			else
			{
				var _rootParent = GetRootParent();
				if (_rootParent != null)
				{
					for (int i = 0; i < _rootParent.Items.Count && i < this.Index; i++)
					{
						var current = _rootParent.Items[i];
						if (current.IsVisible)
						{
							return current;
						}
					}
					return null;
				}
				else return null;
			}
		}

		private TreeNodeViewModel LastVisibleChild()
		{
			TreeNodeViewModel result = null;
			for (int i = 0; i < this.Items.Count; i++)
			{
				var current = this.Items[i];
				if (current.IsVisible)
					result = current;
				else
					this.Items[i].NextVisibleChild();
			}
			return result;
		}

		#region Methods
		public int GetNodeCount(bool includeSubTrees)
		{
			var result = this.Items.Count;
			if (includeSubTrees)
			{
				for (int i = 0; i < this.Items.Count; i++)
				{
					result += this.Items[i].GetNodeCount(includeSubTrees);
				}
			}
			return result;
		}
		/// <summary>
		/// Collapse the tree node
		/// </summary>
		public void Collapse()
		{
			IsExpanded = false;
		}
		/// <summary>
		/// Expands the tree node
		/// </summary>
		public void Expand()
		{
			IsExpanded = true;
		}

		/// <summary>
		/// Expand all the child tree nodes
		/// </summary>
		public void ExpandAll()
		{
			this.IsExpanded = true;
			for (int i = 0; i < this.Items.Count; i++)
			{
				this.Items[i].ExpandAll();
			}
		}

		/// <summary>
		/// Finds a child node by its name
		/// </summary>
		/// <param name="txtKey">Child treenode name</param>
		/// <returns></returns>
		public TreeNodeViewModel FindByKey(string txtKey)
		{
			return this.Items.Find(txtKey, true).FirstOrDefault();
		}
		#endregion

		public void Init(string p1)
		{
			this.CallBaseInit(typeof(TreeNodeViewModel));
			Text = p1;
		}

		public void Init()
		{
			this.CallBaseInit(typeof(TreeNodeViewModel));
		}
	}

	/// <summary>
	///   View model for the TreeView
	/// </summary>
	public class TreeViewViewModel : ControlViewModel
	{
		[JsonProperty("@k")]
		public int k = 1;


		public virtual IList<TreeNodeViewModel> _items { get; set; }

		[StateManagement(StateManagementValues.None)]
		public IList<TreeNodeViewModel> Items { get { return _items; } }

		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
			_items = ctx.Resolve<IList<TreeNodeViewModel>>();
			ImageList = ctx.Resolve<ImageListViewModel>();
			ImageListPrefix = "";
			Visible = true;
			Enabled = true;
			VisibleCount = 0;
		}
		[Reference]
		public virtual ImageListViewModel ImageList { get; set; }

		/// <summary>
		///  Prefix used for the url of image list items
		/// </summary>
		public virtual string ImageListPrefix { get; set; }
		/// <summary>
		/// Default image that is displayed by the tree nodes
		/// </summary>
		public virtual int ImageIndex { get; set; }

		/// <summary>
		///  The UniqueID of the selected node (mainly used for client/server communication)
		/// </summary>
		public virtual string SelectedItemId
		{
			get;
			set;
		}
		/// <summary>
		/// true if the label text of the tree nodes can be edited; otherwise, false.
		/// </summary>
		public bool LabelEdit { get; set; }

		/// <summary>
		/// Gets the amount of visible nodes on the control.
		/// </summary>
		public virtual int VisibleCount { get; set; }
		/// <summary>
		/// Gets or Sets the key of the default image key shown by each tree node
		/// </summary>
		public virtual string ImageKey { get; set; }

		/// <summary>
		///  Transient field used to cache the selected node
		/// </summary>
		TreeNodeViewModel tmpSelectedNode;

		//public override IStateObject CreateItem(object item)
		//{
		//		var result = Container.Resolve<TreeNodeViewModel>();
		//		if (item is Tuple<string, string>)
		//		{
		//				var tuple = (Tuple<string, string>)item;
		//				result.Name = tuple.Item1;
		//				result.Text = tuple.Item2;
		//		}
		//		return result;
		//}

		/// <summary>
		///    Add a new node to the top level of the tree with the specified text
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public TreeNodeViewModel Add(string text)
		{
			return Add("", text);
		}

		public TreeNodeViewModel Add(string key, string text, string imageKey, string selectedImageKey)
		{
			var imageIndex = -1;
			if (ImageList != null && ImageList.Images.ImagesKeys.TryGetValue(imageKey, out imageIndex))
			{
				return Add(key, text, imageIndex);
			}
			return Add(key, text);
		}

		public TreeNodeViewModel Add(TreeNodeViewModel node)
		{
			return Add(node.Name, node.Text);
		}

		/// <summary>
		/// Clears the items collection
		/// </summary>
		public void ClearCollection()
		{
			_items = StaticContainer.Instance.Resolve<IList<TreeNodeViewModel>>();
		}


		/// <summary>
		///    Add a new node to the top level of the tree with the specified text and id
		/// </summary>
		/// <param name="name"></param>
		/// <param name="text"></param>
		/// <returns></returns>				
		public TreeNodeViewModel Add(string name, string text, int imageIndex = -1)
		{
			var result = StaticContainer.Instance.Resolve<TreeNodeViewModel>();
			result.Name = name;
			result.Text = text;
			result.ImageListPrefix = ImageListPrefix;
			result.ImageIndex = imageIndex;
			result.IsVisible = true;
			this.Items.Add(result);
			return result;
		}


		//////////////////////////////////////////////
		///  Calculated properties
		///  

		[StateManagement(StateManagementValues.None)]
		public TreeNodeViewModel SelectedNode
		{
			get
			{

				if (tmpSelectedNode == null
					|| (tmpSelectedNode != null && tmpSelectedNode.UniqueID != this.SelectedItemId))
				{
					tmpSelectedNode = null;
					var tmp = this.Items.FindById(this.SelectedItemId, true);
					if (tmp != null && tmp.Length > 0)
					{
						tmpSelectedNode = tmp[0];
					}
				}
				return tmpSelectedNode ?? this.Items.FirstOrDefault();
			}
			set
			{
                var currentNode = this.Items.FindById(value.UniqueID, true);
                if (currentNode.Length > 0)
                {
                    this.SelectedItemId = currentNode[0].UniqueID;
                }
            }
		}


		/// <summary>
		/// Expand all the nodes
		/// </summary>
		public void ExpandAll()
		{
			this.Items[0].ExpandAll();
		}
		/// <summary>
		/// Finds a child node by its name
		/// </summary>
		/// <param name="txtKey">Child treenode name</param>
		/// <returns></returns>
		public TreeNodeViewModel FindByKey(string txtKey)
		{
			return this.Items.Find(txtKey, true).FirstOrDefault();
		}
	}

	namespace Extensions
	{
		/// <summary>
		///   Extension methods to access the TreeView
		/// </summary>
		public static class TreeViewExtensions
		{
			public static TreeNodeViewModel[] FindById(this IList<TreeNodeViewModel> nodes, string nodeUniqueId,
				bool searchAllChildren)
			{
				return nodes.InnerFind((TreeNodeViewModel node) => node.UniqueID == nodeUniqueId, searchAllChildren);
			}

			public static TreeNodeViewModel[] Find(this IList<TreeNodeViewModel> nodes, string nodeName,
				bool searchAllChildren)
			{
				return nodes.InnerFind((TreeNodeViewModel node) => node.Name == nodeName, searchAllChildren);
			}

			public static TreeNodeViewModel Add(this IList<TreeNodeViewModel> nodes, string text, string key = "", string imageKey = "", string selectedImageKey = "", int selectedImageIndex = -1)
			{
				TreeNodeViewModel node = new TreeNodeViewModel();
				node.Text = text;
				node.Key = key;
				nodes.Add(node);
				return nodes.Last();
			}
			private static void InnerFinding(this TreeNodeViewModel node, Predicate<TreeNodeViewModel> predicate,
				bool searchAllChildren, List<TreeNodeViewModel> results)
			{

				for (int i = 0; i < node.Items.Count; i++)
				{
					var child = node.Items[i];
					InnerSearchInsideChild(predicate, searchAllChildren, results, child);
				}
			}

			private static void InnerSearchInsideChild(Predicate<TreeNodeViewModel> predicate, bool searchAllChildren,
				List<TreeNodeViewModel> results, TreeNodeViewModel child)
			{
				if (predicate(child))
				{
					results.Add(child);
				}
				else
				{
					child.InnerFinding(predicate, searchAllChildren, results);
				}
			}

			private static TreeNodeViewModel[] InnerFind(this IList<TreeNodeViewModel> nodes,
				Predicate<TreeNodeViewModel> predicate, bool searchAllChildren)
			{
				var results = new List<TreeNodeViewModel>();
				for (int i = 0; i < nodes.Count; i++)
				{
					var child = nodes[i];
					InnerSearchInsideChild(predicate, searchAllChildren, results, child);
				}
				return results.ToArray();
			}
		}
	}
}
