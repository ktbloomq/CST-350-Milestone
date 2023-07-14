namespace CST_350_Milestone.Models
{
	public class Button
	{
		public int Row { get; set; }
		public int Column { get; set; }
		public Button(int row, int column)
		{
			Row = row;
			Column = column;
		}
		public Button()
		{
			Row = 0;
			Column = 0;
		}
	}
}
