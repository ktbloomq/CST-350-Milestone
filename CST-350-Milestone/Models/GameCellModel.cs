namespace CST_350_Milestone.Models
{
	public class GameCellModel
	{
		public int ID { get; set; }
		public int Row { get; set; }
		public int Column { get; set; }
		public bool IsVisited { get; set; }
		public bool Live { get; set; }
		public int LiveNeighbors { get; set; }
		public bool IsFlagged { get; set; }

		public GameCellModel(int id) 
		{ 
			ID = id;
			if (id < 10)
			{
				Row = 0; Column = id;
			}
			else
			{
				Row = id / 10; Column = id % 10;
			}
		}

	}
}
