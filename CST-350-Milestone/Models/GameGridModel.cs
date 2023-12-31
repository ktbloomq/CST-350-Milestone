﻿namespace CST_350_Milestone.Models
{
	public class GameGridModel
	{

		public int Size { get; set; }
		public GameCellModel[,] Grid { get; set; }
		public decimal Difficulty { get; set; }

		private List<int> FloodFillList = new List<int>();

		public GameGridModel() { }

		public GameGridModel(int size)
		{
			Size = size;

			Grid = new GameCellModel[Size, Size];
			int idCount = 0;
			for (int row = 0; row < Size; row++)
				for (int col = 0; col < Size; col++)
				{
					Grid[row, col] = new GameCellModel(idCount, Size);
					idCount++;
				}
					
			
		}

		public void SetupLiveNeighbors()
		{
			//Determines the number of cells that be live based on difficulty
			decimal livePercentage = Difficulty / 100.0m;
			int liveCount = (int)(Grid.Length * livePercentage);

			//Creates a list of GameCells in the grid
			List<GameCellModel> cells = new List<GameCellModel>();
			for (int row = 0; row < Grid.GetLength(0); row++)
			{
				for (int col = 0; col < Grid.GetLength(1); col++)
				{
					cells.Add(Grid[row, col]);
				}
			}

			//Shuffle the list of cells to randomize the live cell placements
			Random rng = new Random();
			cells = cells.OrderBy(c => rng.Next()).ToList();

			//Set the first liveCount cells in the shuffled list to live status
			for (int i = 0; i < liveCount; i++)
			{
				cells[i].Live = true;

			}
		}

		public void CalculateLiveNeighbors()
		{
			for (int row = 0; row < Grid.GetLength(0); row++)
			{
				for (int col = 0; col < Grid.GetLength(1); col++)
				{
					GameCellModel cell = Grid[row, col];

					//If the cell itself is live, set the neighbor count to 9
					if (cell.Live)
					{
						cell.LiveNeighbors = 9;
					}
					else
					{
						//Count the number of live neighbors for the current cell
						int liveNeighbors = 0;
						for (int i = row - 1; i <= row + 1; i++)
						{
							for (int j = col - 1; j <= col + 1; j++)
							{
								if (i >= 0 && i < Grid.GetLength(0) && j >= 0 && j < Grid.GetLength(1))
								{
									if (Grid[i, j].Live)
									{
										liveNeighbors++;
									}
								}
							}
						}
						cell.LiveNeighbors = liveNeighbors;
					}
				}
			}
		}

		public void reveal(int row, int col)
		{
			Grid[row, col].IsVisited = true;
		}

		public List<int> FloodFill(int row, int col)
		{


			if (row < 0 || row >= Grid.GetLength(0) || col < 0 || col >= Grid.GetLength(1))
			{
				return FloodFillList; // Invalid cell
			}

			GameCellModel cell = Grid[row, col];
			

			if (cell.IsVisited)
			{
				return FloodFillList; // Cell already visited
			}


			if (cell.Live == true)
			{
				return FloodFillList;  //Cell is live
			}

			cell.IsVisited = true;
			FloodFillList.Add(cell.Id);

			if (cell.LiveNeighbors > 0)
			{
				return FloodFillList;
			}

			// Recursively call floodFill on surrounding cells
			FloodFill(row - 1, col); // Up
			FloodFill(row + 1, col); // Down
			FloodFill(row, col - 1); // Left
			FloodFill(row, col + 1); // Right
			FloodFill(row + 1, col + 1); // SE
			FloodFill(row + 1, col - 1); // NE
			FloodFill(row - 1, col + 1); // SW
			FloodFill(row - 1, col - 1); // NW

			return FloodFillList;
		}

		public void ClearFloodFillList()
		{
			FloodFillList.Clear();
		}

		public void RevealBombs()
		{
			foreach (var cell in Grid)
			{
				if (cell.Live)
				{
					cell.IsVisited = true;
					cell.IsFlagged = false;
				}
			}
		}

		public bool HaveWon()
		{

			foreach (var cell in Grid)
			{
				if (!cell.Live && !cell.IsVisited)
				{
					// Console.WriteLine("space {0} {1} has not been visited", cell.Row, cell.Column);
					return false;
				}
			}

			return true;
		}

	}
}
