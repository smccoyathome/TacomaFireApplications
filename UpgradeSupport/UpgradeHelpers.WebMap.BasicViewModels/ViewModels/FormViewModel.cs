using System;
using System.ComponentModel;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels
{
   /// <summary>
   /// Generic ViewModel used to represent the ViewModel of an empty form
   /// </summary>
   public class FormViewModel 
   {
       /// <summary>
       /// Setup the model properties with its default values
       /// </summary>
       public void Build(IIocContainer ctx)
       {		        
         // Enabled DefaultValue
         Enabled = true;

         // Visible DefaultValue
         Visible = true;       
      }

      #region Data Members
      /// <summary>
      /// Returns a name that will be used in to view that presents this model
      /// </summary>
      public virtual string Name { get; set; }

      /// <summary>
      /// Gets or sets a value indicating whether in the view the element that represents this model can respond to user interaction
      /// </summary>
      [DefaultValue(true)]
      public virtual bool Enabled { get; set; }

      /// <summary>
      /// Gets or sets a value indicating whether in the view the element that represent this model is displayed
      /// </summary>
      [DefaultValue(true)]
      public virtual bool Visible { get; set; }

      /// <summary>
      /// Gets or sets the font of the text that the view will use to display text
      /// </summary>
      [DefaultValue(null)]
      public virtual Font Font { get; set; }

      /// <summary>
      /// Gets or sets the distance in pixels between the top edge of the the element of the view that represents this model 
      /// and the top edge of the element in the view that contains it
      /// and the
      /// </summary>
      [DefaultValue(0)]
      public virtual int Top { get; set; }

      /// <summary>
      /// Gets or sets the distance in pixels, between the 
      /// left edge of the element in the view that represents this model 
      /// and the left edge of the element of the view that contains it
      /// </summary>
      [DefaultValue(0)]
      public virtual int Left { get; set; }

      /// <summary>
      /// Gets or sets the height in pixels for the element in the view that will represent this model
      /// </summary>
      [DefaultValue(0)]
      public virtual int Height { get; set; }

      /// <summary>
      /// Gets or sets the Width in pixels for the element in the view that will represent this model
      /// </summary>
      [DefaultValue(0)]
      public virtual int Width { get; set; }

      /// <summary>
      /// Gets or sets the tab order of the element in the view that  that will represent this model 
      /// </summary>
      [DefaultValue(-1)]
      public virtual int TabIndex { get; set; }

      /// <summary>
      /// Gets or sets the background color that will be used by the element tin
      /// the view that will represent this model
      /// </summary>
      [DefaultValue(null)]
      public virtual Color BackColor { get; set; }

      /// <summary>
      /// Gets or sets the foreground color that will be used by the element tin
      /// the view that will represent this model
      /// </summary>
      [DefaultValue(null)]
      public virtual Color ForeColor { get; set; }

      /// <summary>
      /// Gets or sets generic data
      /// </summary>
      
      public virtual object Tag { get; set; }

      /// <summary>
      /// Gets or sets the text associated with this model
      /// </summary>
      public virtual string Text { get; set; }

      /// <summary>
      /// Legacy property. This property should not be used.
      /// Is just left for compilation.
      /// </summary>
      [Obsolete("Remove any use of this property")]
      public virtual IntPtr Handle { get; set; }

      /// <summary>
      /// Legacy property. This property should not be used.
      /// Is just left for compilation.
      /// </summary>
      [Obsolete("Remove any use of this property")]
      public virtual Cursor Cursor { get; set; }
      #endregion


  }
}
