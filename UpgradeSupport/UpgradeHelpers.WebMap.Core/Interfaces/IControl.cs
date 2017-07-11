namespace UpgradeHelpers.Interfaces
{
	public interface IControl: IStateObject
	{
		string Name { get; set; }

		bool Enabled { get; set; }

		object Tag { get; set; }

		bool Visible { get; set; }

		//Helpers.Font Font { get; set; }

		int Top { get; set; }

		int Left { get; set; }

		int Height { get; set; }

		int Width { get; set; }

		int TabIndex { get; set; }

		//Helpers.Color BackColor { get; set; }

		//Helpers.Color ForeColor { get; set; }

		string Text { get; set; }

		void BringToFront();
	}
}
