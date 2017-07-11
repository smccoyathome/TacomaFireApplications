namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Specifies how to trim characters from a string that does not completely fit
	//     into a layout shape.
	public enum StringTrimming
    {
        // Summary:
        //     Specifies no trimming.
        None = 0,
        //
        // Summary:
        //     Specifies that the text is trimmed to the nearest character.
        Character = 1,
        //
        // Summary:
        //     Specifies that text is trimmed to the nearest word.
        Word = 2,
        //
        // Summary:
        //     Specifies that the text is trimmed to the nearest character, and an ellipsis
        //     is inserted at the end of a trimmed line.
        EllipsisCharacter = 3,
        //
        // Summary:
        //     Specifies that text is trimmed to the nearest word, and an ellipsis is inserted
        //     at the end of a trimmed line.
        EllipsisWord = 4,
        //
        // Summary:
        //     The center is removed from trimmed lines and replaced by an ellipsis. The
        //     algorithm keeps as much of the last slash-delimited segment of the line as
        //     possible.
        EllipsisPath = 5,
    }
}
