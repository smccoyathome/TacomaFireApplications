namespace UpgradeHelpers.BasicViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Text;
    using UpgradeHelpers.Helpers;
    using UpgradeHelpers.Interfaces;

    public class ImageListViewModel : IDependentViewModel
    {
        internal const string DEFAULTEXTRACTEDIMAGESFORMAT = ".png";
        internal const string DEFAULTEXTRACTEDIMAGESPATH = "~/Resources/Images/";

        public string UniqueID { get; set; }

        public virtual string ImageStream { get; set; }

        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual ImageCollection Images { get; set; }

        public void Build(IIocContainer ctx)
        {
            this.Images = ctx.Resolve<ImageCollection>();
            this.Images.ParentImageList = this;
        }

        public class ImageCollection : IDependentViewModel
        {
            [StateManagement(StateManagementValues.ServerOnly)]
            public virtual ImageListViewModel ParentImageList { get; set; }

            public string UniqueID { get; set; }

            public virtual IList<string> ImagesNames { get; set; }

            public virtual IDictionary<string, int> ImagesKeys { get; set; }

            public int Count => this.ImagesNames.Count;

            public virtual string this[int index]
            {
                get { return this.ImagesNames[index]; }

                set { this.ImagesNames[index] = value; }
            }

            public virtual string this[string key]
            {
                get
                {
                    int index;
                    this.ImagesKeys.TryGetValue(key, out index);
                    return this.ImagesNames.Count > index ? this.ImagesNames[index] : string.Empty;
                }
            }

            public virtual int Add(string item)
            {
                this.ImagesNames.Add(item);
                return this.ImagesNames.Count - 1;
            }

            public virtual void Clear()
            {
                this.ImagesNames.Clear();
            }

            public virtual void RemoveAt(int index)
            {
                this.ImagesNames.RemoveAt(index);
            }

            public virtual void Insert(int index, string item)
            {
                this.ImagesNames.Insert(index, item);
            }

            public IEnumerator<string> GetEnumerator()
            {
                return this.ImagesNames.GetEnumerator();
            }

            public virtual void SetKeyName(int index, string key)
            {
                // Update the key associated with the index
                int storedIndex;
                if (this.ImagesKeys.TryGetValue(key, out storedIndex))
                {
                    this.ImagesKeys[key] = index;
                }
                else
                {
                    this.ImagesKeys.Add(key, index);
                    this.ImagesNames.Add(this.BuildExtractedNameForImage(index));
                }
            }

            public virtual void Build(IIocContainer ctx)
            {
                this.ImagesNames = ctx.Resolve<IList<string>>();
                this.ImagesKeys = ctx.Resolve<IDictionary<string, int>>();
            }

            private string BuildExtractedNameForImage(int imageListIndex)
            {
                string resolvedImage = string.Empty;
                if (this.ParentImageList != null && this.ParentImageList.ImageStream != string.Empty)
                {
                    return this.ParentImageList.ImageStream + imageListIndex + ImageListViewModel.DEFAULTEXTRACTEDIMAGESFORMAT;
                }

                return resolvedImage;
            }
        }
    }
}
