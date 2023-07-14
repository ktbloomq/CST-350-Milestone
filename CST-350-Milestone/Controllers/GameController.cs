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
			Console.WriteLine(board.Difficulty);
			return View(board);
		}

		public IActionResult Play(int row, int col)
		{
			Console.WriteLine("Row: {0}\nCol: {1}", row, col);
			board.Grid[row,col].Visted = true;
			return View("Index", board);
		}
	}
}
