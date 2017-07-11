namespace UpgradeHelpers.BasicViewModels
{
    using System.ComponentModel;
    using UpgradeHelpers.Helpers;
    using UpgradeHelpers.Interfaces;

    /// <summary>
    /// Represents a model that can be used on the view to display or edit unformatted text
    /// </summary>
    public class LabelViewModel : ControlViewModel
    {
        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual ImageListViewModel _imageList { get; set; }

        [StateManagement(StateManagementValues.None)]
        public ImageListViewModel ImageList
        {
            get
            {
                return this._imageList;
            }

            set
            {
                if (value != null && value.Images.Count > this.ImageIndex)
                {
                    this.Image = value.Images[this.ImageIndex];
                }

                this._imageList = value;
            }
        }

        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual int _imageIndex { get; set; }

        [StateManagement(StateManagementValues.None)]
        public virtual int ImageIndex
        {
            get
            {
                return this._imageIndex;
            }

            set
            {
                if (string.IsNullOrEmpty(this._imagePath) && this.ImageList != null && this.ImageList.Images.Count > value)
                {
                    this.ImagePath = this.ImageList.Images[value];
                }

                this._imageIndex = value;
            }
        }

        public virtual string _image { get; set; }

        [StateManagement(StateManagementValues.None)]
        public string Image
        {
            get
            {
                return _image;
            }

            set
            {
                _image = value;
                ImagePath = value;
            }
        }

        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual string _imagePath { get; set; }

        /// <summary>
        /// This property will have the path of the image shown in the label, it could be obtained by the image property or the image index in the image list
        /// </summary>
        [StateManagement(StateManagementValues.ClientOnly)]
        public virtual string ImagePath
        {
            get
            {
                string imagePath = this._imagePath;
                if (string.IsNullOrEmpty(this._imagePath) && this.ImageList != null && this.ImageList.Images.Count > this.ImageIndex)
                {
                    this._imagePath = this.ImageList.Images[this.ImageIndex];
                }

                return ImageListViewModel.DEFAULTEXTRACTEDIMAGESPATH + _imagePath;
            }

            set
            {
                _imagePath = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [StateManagement(StateManagementValues.Both)]
        public override bool AllowDrop
        {
            get
            {
                return base.AllowDrop;
            }

            set
            {
                base.AllowDrop = value;
            }
        }

        /// <summary>
        /// Setup the model properties with its default values
        /// </summary>
        public override void Build(IIocContainer ctx)
        {
            base.Build(ctx);
        }

        public virtual void OnNavigate() { }

        public virtual void OnRemove() { }

        public virtual void OnActivated() { }
    }
}