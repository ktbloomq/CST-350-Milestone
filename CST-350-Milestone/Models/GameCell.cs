namespace CST_350_Milestone.Models
{
	public class GameCell
	{
		public int Row { get; set; }
		public int Column { get; set; }
		public bool IsVisited { get; set; }
		public bool Live { get; set; }
		public int LiveNeighbors { get; set; }
		public bool IsFlagged { get; set; }

        public GameCell(int row, int column, bool isVisted, bool live, int liveNeighbors, bool isFlagged)
        {
            Row = row;
            Column = column;
            IsVisited = isVisted;
            Live = live;
            LiveNeighbors = liveNeighbors;
            IsFlagged = isFlagged;
        }

        public GameCell()
        {
            Row = -1;
            Column = -1;
            IsVisited = false;
            Live = false;
            LiveNeighbors = 0;
            IsFlagged = false;
        }

    }
}
