using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class GameBoard
    {
        public int Size { get; set; }
        public GameCell[,] Grid { get; set; }
        public decimal Difficulty { get; set; }


        public GameBoard(int size)
        {
            Size = size;

            Grid = new GameCell[size, size];

            //Initialize each cell in the grid
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Grid[row, col] = new GameCell();
                }
            }
        }

        public void SetupLiveNeighbors()
        {
            //Determines the number of cells that be live based on difficulty
            decimal livePercentage = Difficulty / 100.0m;
            int liveCount = (int)(Grid.Length * livePercentage);

            //Creates a list of GameCells in the grid
            List<GameCell> cells = new List<GameCell>();
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
                    GameCell cell = Grid[row, col];

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
        public void FloodFill(int row, int col)
        {
            if (row < 0 || row >= Grid.GetLength(0) || col < 0 || col >= Grid.GetLength(1))
            {
                return; // Invalid cell
            }

            GameCell cell = Grid[row, col];

            if (cell.Visted)
            {
                return; // Cell already visited
            }

            if (cell.Live == true)
            {
                return;  //Cell is live
            }

            cell.Visted = true;

            if (cell.LiveNeighbors > 0)
            {
                return;
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
        }
        public void ClearBombs()    //This method is used to reset the gameboard to a clean state, so a new game can begin. 
        {
            for (int row = 0; row < Grid.GetLength(0); row++)
            {
                for (int col = 0; col < Grid.GetLength(1); col++)
                {
                    Grid[row, col].Live = false;
                    Grid[row, col].Visted = false;
                }
            }
        }
    }
}
