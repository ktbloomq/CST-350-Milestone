namespace CST_350_Milestone.Models
{
	public class GameCellModel
	{
		public int Id { get; set; }
		public int Row { get; set; }
		public int Column { get; set; }
		public bool IsVisited { get; set; }
		public bool Live { get; set; }
		public int LiveNeighbors { get; set; }
		public bool IsFlagged { get; set; }

		public GameCellModel(int id, int boardSize) 
		{
			Id = id;
			if (id < boardSize)
			{
				Row = 0; Column = id;
			}
			else
			{
				Row = id / boardSize; Column = id % boardSize;
			}
			IsVisited = false;
			LiveNeighbors = 0;
			IsFlagged = false;
			Live = false;
		}

		public GameCellModel() { }

	}
}
