using System.Drawing;
using CST_350_Milestone.Models;
using Newtonsoft.Json;

namespace CST_350_Milestone.Services
{
	public class GameService
	{
		public GameGridModel grid;
		public bool won = false;
		public bool lost = false;
		public GameService(int size, int difficulty) 
		{
			grid = new(size);
			grid.Difficulty = difficulty;
			grid.SetupLiveNeighbors();
			grid.CalculateLiveNeighbors();
		}

		public GameService(string gameState)
		{
			grid = JsonConvert.DeserializeObject<GameGridModel>(gameState);
		}

		public GameCellModel update(int buttonNumber)
		{
			// convert id into row col pair
			int row = buttonNumber / grid.Size;
			int col = buttonNumber % grid.Size;
			// Console.WriteLine(row + " " + col);
			grid.reveal(row, col);
			GameCellModel cell = grid.Grid[row, col];
			cell.IsVisited = true;

			if (cell.Live)
			{
				lost = true;
			} else if (grid.HaveWon())
			{
				Console.WriteLine("Service won");
				won = true;
			}

			return cell;
		}

		public void RevealBombs()
		{
			grid.RevealBombs();
		}

		public GameCellModel flag(int buttonNumber)
		{
			GameCellModel cell = grid.Grid[buttonNumber / grid.Size, buttonNumber % grid.Size];
			cell.IsFlagged = !cell.IsFlagged;
			return cell;
		}
	}
}
