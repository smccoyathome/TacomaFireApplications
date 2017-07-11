using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpgradeHelpers.Helpers;
using System.Runtime.Serialization;

namespace UpgradeHelpers.Events
{
    [Serializable]
    public class ItemCheckEventArgs : EventArgs, ISerializable
    {
        public virtual System.Int32 Index { get; set; }
        public virtual CheckState CurrentValue { get; set; }
        public virtual CheckState NewValue { get; set; }

        public ItemCheckEventArgs(int index, CheckState newCheckValue, CheckState currentValue)
        {
            Index = index;
            NewValue = newCheckValue;
            CurrentValue = currentValue;
        }

        public ItemCheckEventArgs(int index, bool newCheckValue)
        {
            Index = index;
            NewValue = newCheckValue ? CheckState.Checked : CheckState.Unchecked;
            CurrentValue = !newCheckValue ? CheckState.Checked : CheckState.Unchecked;
        }

        public ItemCheckEventArgs()
        {
            // TODO: Complete member initialization
        }
        protected ItemCheckEventArgs(SerializationInfo info, StreamingContext context)
        {
            Index = info.GetInt32("index");
            CurrentValue = (CheckState)info.GetInt32("CurrentValue");
            NewValue = (CheckState)info.GetInt32("NewValue");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("index", Index);
            info.AddValue("CurrentValue", CurrentValue);
            info.AddValue("NewValue", NewValue);
        }

    }
}
