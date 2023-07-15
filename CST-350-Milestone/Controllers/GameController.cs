using CST_350_Milestone.Models;
using Microsoft.AspNetCore.Mvc;

namespace CST_350_Milestone.Controllers
{
	public class GameController : Controller
	{
		public static GameBoard board = null;
		public IActionResult Index(decimal difficulty, int size)
		{
			if (size == 0 && difficulty == 0)
			{
				size = 8;
				difficulty = 10;
			}
			board = new GameBoard(size);
			board.Difficulty = difficulty;
			board.SetupLiveNeighbors();
			board.CalculateLiveNeighbors();
			return View(board);
		}

		public IActionResult Play(int row, int col)
		{
			// Console.WriteLine("Row: {0}\nCol: {1}", row, col);
			board.FloodFill(row, col);
			if (board.Grid[row, col].Live)
			{
				return View("lose");
			}
			if(IsGameWon())
			{
				return View("win");
			}
			return View("Index", board);
		}

		public bool IsGameWon()
		{
			for (int row = 0; row < board.Grid.GetLength(0); row++)
			{
				for (int col = 0; col < board.Grid.GetLength(1); col++)
				{
					GameCell cell = board.Grid[row, col];
					if (!cell.Visted && !cell.Live)
					{
						return false; // There are still unvisited non-mine cells
					}
				}
			}
			return true;
		}
	}
}


