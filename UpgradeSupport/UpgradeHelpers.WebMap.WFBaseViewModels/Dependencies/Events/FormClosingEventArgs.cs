using System;

namespace UpgradeHelpers.Events
{
	/// <summary>
	///     This class defines the closing event args event for compilation purposes only.
	/// </summary>
	public class FormClosingEventArgs : CancelEventArgs
    {
        public FormClosingEventArgs(CloseReason closeReason, bool cancel)
        {
			this.CloseReason = closeReason;
			this.Cancel = cancel;
		}

        public CloseReason CloseReason { get; set; }

        [Obsolete("only generated for compilation")]
        public int Get_CloseReason()
        {
            throw new NotImplementedException();
        }
    }
}