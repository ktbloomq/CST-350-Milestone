using CST_350_Milestone.Models;
using Microsoft.AspNetCore.Mvc;

namespace CST_350_Milestone.Controllers
{
	public class GameController : Controller
	{
		public GameBoard board = null;
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
			Console.WriteLine(board.Difficulty);
			return View(board);
		}

		public IActionResult HandleButton(int id)
		{
			Console.WriteLine("button click");
			Console.WriteLine(id);
			Console.WriteLine(board.Difficulty);
			//Console.WriteLine("Id: {0}\nRow: {1}\nCol: {2}", cells[id].ID, cells[id].Row, cells[id].Column);
			return View("index",board);
		}
	}
}
