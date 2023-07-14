namespace CST_350_Milestone.Models
{
    public class GameCell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool Visted { get; set; }
        public bool Live { get; set; }
        public int LiveNeighbors { get; set; }
        public bool Flag { get; set; }

        public GameCell(int row, int column, bool visted, bool live, int liveNeighbors, bool flag)
        {
            Row = row;
            Column = column;
            Visted = visted;
            Live = live;
            LiveNeighbors = liveNeighbors;
            Flag = flag;
        }

        public GameCell()
        {
            Row = -1;
            Column = -1;
            Visted = false;
            Live = false;
            LiveNeighbors = 0;
            Flag = false;
        }
    }
}
