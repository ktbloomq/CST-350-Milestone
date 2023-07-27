using CST_350_Milestone.Models;
using CST_350_Milestone.Services;
using Microsoft.AspNetCore.Mvc;


namespace CST_350_Milestone.Controllers
{
	public class GameController : Controller
	{
		//static GameGridModel grid = null;
		static GameService game = null;

		public IActionResult Index(int difficulty, int size)
		{
			if (size == 0 && difficulty == 0)
			{
				size = 8;
				difficulty = 10;
			}
			else
			{
				difficulty = difficulty * 10; //Planning on having difficulty set at
											  //levels one, two and three
			}

			game = new(size, difficulty);

			return View("Index", game.grid);
		}

		public IActionResult Win()
		{
			return View("WonGame");
		}

		public IActionResult Lose()
		{
			return View("Index", game.grid);
		}

		/*
		public IActionResult HandleButtonClick(int gridID)
		{
			int row = 0;
			int col = 0;
			int size = grid.Size;
			
			if (gridID >= size)
			{
				row = gridID / size;
				col = gridID % size;
			}
			else
			{
				col = gridID % size;
			}
			GameCellModel cell = grid.Grid[row, col];

			grid.FloodFill(row, col);

			if (cell.Live)
			{
				grid.RevealBombs();
				return View("LostGame");
			} 
			else if (grid.HaveWon())
			{
				return View("WonGame");
			}

			return View("Index", grid);
		}
		*/

		public IActionResult Reveal(int buttonNumber)
		{
			int row = 0;
			if (buttonNumber >= game.grid.Size)
			{
				row = buttonNumber / game.grid.Size;
			}
			int col = buttonNumber % game.grid.Size;

			List<int> ids = game.grid.FloodFill(row, col);
			game.grid.ClearFloodFillList();

			return Json(ids);
		}

		public IActionResult ShowOneButton(int buttonNumber)
		{
			GameCellModel cell = game.update(buttonNumber);



			// win/loss detection
			if (game.lost)
			{
				// Console.WriteLine("lost");
				game.RevealBombs();
				return Json(new { status = "lose" });
			}
			else if (game.won)
			{
				Console.WriteLine("Controller won!");
				return Json(new { status = "win" });
			}


			return PartialView(cell);
		}

		public IActionResult Flag(int buttonNumber)
		{
			GameCellModel cell = game.flag(buttonNumber);

			return PartialView("ShowOneButton", cell);
		}
	}
}
