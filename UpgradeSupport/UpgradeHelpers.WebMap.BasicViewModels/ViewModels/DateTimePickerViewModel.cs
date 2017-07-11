using System;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace UpgradeHelpers.BasicViewModels
{
    /// <summary>
    /// A ViewModel to keep the state of a datime picker
    /// </summary>
    public class DateTimePickerViewModel : ControlViewModel
    {
        #region Data Members
        ///Gets or sets the date/time value assigned to the control.
        public virtual DateTime Value { get; set; }

        [JsonProperty(PropertyName = "MinDate")]
        public virtual DateTime _minDate { get; set; }

        [StateManagement(StateManagementValues.None)]
        public DateTime MinDate
        {
            get
            {
                return _minDate;
            }
            set
            {
                _minDate = value;
                //Sets the minDate to the value when the
                //current value is less than the minDate value.
                if (this._minDate != null)
                {
                    var currentValue = (DateTime)Value;
                    var result = DateTime.Compare(_minDate, currentValue);
                    if (result > 0)
                    {
                        Value = _minDate;
                    }
                }
            }
        }

        [JsonProperty(PropertyName = "MaxDate")]
        public virtual DateTime _maxDate { get; set; }

        [StateManagement(StateManagementValues.None)]
        public DateTime MaxDate
        {
            get
            {
                return _maxDate;
            }
            set
            {
                _maxDate = value;
                //Sets the minDate to the value when the
                //current value is less than the minDate value.
                if (this._maxDate != null)
                {
                    var currentValue = Value;
                    var result = DateTime.Compare(_maxDate, currentValue);
                    if (result < 0)
                    {
                        Value = _maxDate;
                    }
                }
            }
        }

        #endregion

        #region Events
        private event EventHandler _ValueChanged;
        public event EventHandler ValueChanged
        {
            add
            {
                _ValueChanged += value;
            }
            remove
            {
                _ValueChanged -= value;
            }
        }

        public void OnValueChanged()
        {
            if (_ValueChanged != null)
            {
                _ValueChanged(this, new EventArgs());
            }
        }

        #endregion


        /// <summary>
        /// Setup the model properties with its default values
        /// </summary>
        public override void Build(IIocContainer ctx)
        {
            base.Build(ctx);
            Value = DateTime.Now;
            MinDate = DateTime.MinValue;
            MaxDate = DateTime.MaxValue;
        }

        public DateTime GetValue()
        {
            return (DateTime)Value;
        }

        public void SetValue(DateTime dateTime)
        {
            Value = dateTime;
        }
    }
}
