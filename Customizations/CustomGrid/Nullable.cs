namespace Custom.ViewModels.Grid
{
	//
	// Summary:
	//     Used to specify the way null values are stored.
	public enum Nullable
	{
		//     Automatic. Data stored as null if allowed, otherwise as empty string.
		Automatic = 0,
		//     DBNull. Data stored as DBNull value.
		Null = 1,
		//     Empty String. Data stored as a zero-length string.
		EmptyString = 2,
		//     Nothing. Data stored as Nothing (C# null).
		Nothing = 3,
		//     Column doesn't allow empty values.
		Disallow = 4
	}
}
