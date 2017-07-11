namespace UpgradeHelpers.BasicViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using UpgradeHelpers.Events;
    using UpgradeHelpers.Helpers;
    using UpgradeHelpers.Interfaces;
    /// <summary>
    /// Defines how to format the control's text
    /// </summary>
    public enum MaskFormat
	{
		// Summary:
		//     Return only text input by the user.
		ExcludePromptAndLiterals = 0,
		//
		// Summary:
		//     Return text input by the user as well as any instances of the prompt character.
		IncludePrompt = 1,
		//
		// Summary:
		//     Return text input by the user as well as any literal characters defined in
		//     the mask.
		IncludeLiterals = 2,
		//
		// Summary:
		//     Return text input by the user as well as any literal characters defined in
		//     the mask and any instances of the prompt character.
		IncludePromptAndLiterals = 3,
	}
	public class MaskedTextBoxViewModel : ControlViewModel
	{
		private const string TypeValidationEvent = "TypeValidationCompleted";
		/// <summary>
		///     Setup the model properties with its default values
		/// </summary>
		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
			// ReadOnly DefaultValue
			ReadOnly = false;
			//PromptChar DefaultValue
			PromptChar = '_';

			//TextMaskFormat DefaultValue
			TextMaskFormat = MaskFormat.IncludeLiterals;

            base.BackColor = UpgradeHelpers.Helpers.Color.White;
		}

		#region Data Members
		/// <summary>
		///     Gets or sets a value indicating whether in the view the element that represents this model can modified the Text.
		/// </summary>
		[DefaultValue(false)]
		public virtual bool ReadOnly { get; set; }
		/// <summary>
		/// Gets or sets selection start property
		/// </summary>
		public virtual int SelectionStart { get; set; }
		/// <summary>
		/// Gets or sets selection length property
		/// </summary>
		public virtual int SelectionLength { get; set; }

		/// <summary>
		///     Gets or sets the text value used by the element in the view that will represent this model
		/// </summary>
		private string _text = string.Empty;
		[StateManagement(StateManagementValues.ServerOnly)]
		public virtual string _unmodifiedText { get; set; }

		static Dictionary<char, Regex> cachedRegexIncludePrompt = new Dictionary<char, Regex>();
		static Regex rgxForExcludePromptAndLiterals = new Regex("[^a-zA-Z0-9]");

		public override string Text
		{
			get
			{

				switch (TextMaskFormat)
				{
					case MaskFormat.IncludePromptAndLiterals:
						{
							break;
						}
					case MaskFormat.IncludePrompt:
						{
							Regex rgx;
							if (!cachedRegexIncludePrompt.TryGetValue(PromptChar, out rgx))
							{
								rgx = new Regex("[^a-zA-Z0-9" + PromptChar + "]");
								cachedRegexIncludePrompt[PromptChar] = rgx;
							}
							_text = rgx.Replace(_text, "");
							break;

						}
					case MaskFormat.IncludeLiterals:
						{
							_text = _text.Replace("" + PromptChar, "");
							break;

						}
					case MaskFormat.ExcludePromptAndLiterals:
						{

							_text = rgxForExcludePromptAndLiterals.Replace(_text, "");
							break;

						}

				}
				if (ViewManager != null && ViewManager.Events != null && !ViewManager.Events.IsSuspended())
					ValidateText();
				return _text;


			}
			set
			{
				_text = value;
				if (Mask != null && (Mask.Length == value.Length))
					this._unmodifiedText = value;
			}
		}

		/// <summary>
		///     Gets or sets the prompt character value used by the element in the view that will represent this model
		/// </summary>
		[DefaultValue("")]
		public virtual char PromptChar { get; set; }

		/// <summary>
		/// Gets or sets the input mask
		/// </summary>
		[DefaultValue("")]
		public virtual string Mask { get; set; }

		/// <summary>
		/// Gets or Sets the value whether literals and prompt
		/// </summary>
		public virtual MaskFormat TextMaskFormat { get; set; }

		/// <summary>
		/// Gets or sets the datatype used to verify the data input by the user
		/// </summary>
		[StateManagement(StateManagementValues.ServerOnly)]
		public virtual Type ValidatingType { get; set; }
		/// <summary>
		/// Gets a value indicating whether the formatted input string was successfully converted to the validating type.
		/// </summary>
		[DefaultValue(true)]
		public bool IsValidInput { get; set; }
		/// <summary>
		/// Creates a new EventArguments for event raised from the client
		/// </summary>
		[StateManagement(StateManagementValues.ServerOnly)]
		public TypeValidationEventArgs TypeValEventArgs
		{
			get
			{
				object propValue = null;
				string message = string.Empty;
				IsValidInput = isValid(out propValue, ref message);
				return new TypeValidationEventArgs(ValidatingType, IsValidInput, propValue, message);
			}

		}

		#endregion



		#region Methods
		/// <summary>
		/// Clears all text from the control
		/// </summary>
		public void Clear()
		{
			this.Text = "";
		}
		/// <summary>
		/// Converts the user input string to an instance of the validating type 
		/// </summary>
		/// <returns></returns>
		public Object ValidateText()
		{

			if (ValidatingType != null)
			{
				string message = string.Empty;
				object propValue;
				IsValidInput = isValid(out propValue, ref message);
				if (ViewManager != null)
					ViewManager.Events.Publish(TypeValidationEvent, this, new TypeValidationEventArgs(ValidatingType, IsValidInput, propValue, message));
				return propValue;
			}
			else
				return null;

		}

		private bool isValid(out object propValue, ref string message)
		{
			try
			{
				if (ValidatingType != null)
				{
					TypeConverter typeConverter = TypeDescriptor.GetConverter(ValidatingType);
					propValue = typeConverter.ConvertFromString(_unmodifiedText);
					message = string.Empty;
					return true;
				}
				else
				{
					propValue = null;
					return false;
				}
			}
			catch (Exception e)
			{
				message = e.ToString();
				propValue = null;
				return false;
			}
		}
		#endregion
	}
}