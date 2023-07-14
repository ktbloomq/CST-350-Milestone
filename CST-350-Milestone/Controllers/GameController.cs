using Microsoft.AspNetCore.Mvc;
using Minesweeper;

namespace CST_350_Milestone.Controllers
{
	public class GameController : Controller
	{
		public GameBoard board = null;
		public IActionResult Index(int difficulty, int size)
		{
			if (size == 0 && difficulty == 0)
			{
				size = 8;
				difficulty = 1;
			}
			board = new GameBoard(size);
			board.Difficulty = difficulty;
			board.CalculateLiveNeighbors();
			return View(board);
		}

		public IActionResult HandleButton(int id)
		{
			//Console.WriteLine("Id: {0}\nRow: {1}\nCol: {2}", cells[id].ID, cells[id].Row, cells[id].Column);
			return View("Index",board);
		}
	}
}
