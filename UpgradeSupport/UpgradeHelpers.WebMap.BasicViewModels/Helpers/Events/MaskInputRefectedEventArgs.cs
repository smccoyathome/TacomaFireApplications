using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeHelpers.Events
{

	/// <summary>
	///     Event args class for MaskInputReject event handlers.  This class is provided for compilation purposes only,
	///     because mouse events are not server propagated to server side, instead they are
	///     converted to client side events (such as JavaScript)
	/// </summary>
	public class MaskInputRejectedEventArgs : EventArgs
	{

		public MaskInputRejectedEventArgs(int position, MaskedTextResultHint rejectionHint)
		{
			this.Position = position;
			this.RejectionHint = rejectionHint;
		}
		public int Position { get; set; }
		public MaskedTextResultHint RejectionHint { get; set; }
	}
	// Summary:
	//     Specifies values that succinctly describe the results of a masked text parsing
	//     operation.
	public enum MaskedTextResultHint
	{
		PositionOutOfRange = -55,
		NonEditPosition = -54,
		UnavailableEditPosition = -53,
		PromptCharNotAllowed = -52,
		InvalidInput = -51,
		SignedDigitExpected = -5,
		LetterExpected = -4,
		DigitExpected = -3,
		AlphanumericCharacterExpected = -2,
		AsciiCharacterExpected = -1,
		Unknown = 0,
		CharacterEscaped = 1,
		NoEffect = 2,
		SideEffect = 3,
		Success = 4,
	}
}