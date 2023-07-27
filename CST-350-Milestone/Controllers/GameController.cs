using CST_350_Milestone.Models;
using Microsoft.AspNetCore.Mvc;


namespace CST_350_Milestone.Controllers
{
	public class GameController : Controller
	{
		static GameGridModel grid = null;

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

			grid = new(size);
			grid.Difficulty = difficulty;
			grid.SetupLiveNeighbors();
			grid.CalculateLiveNeighbors();

			return View("Index", grid);
		}

		public IActionResult Win()
		{
			return View("WonGame");
		}

		public IActionResult Lose()
		{
			return View("Index", grid);
		}

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

		public IActionResult ShowOneButton(int buttonNumber)
		{
			// convert id into row col pair
			int row = buttonNumber / grid.Size;
			int col = buttonNumber % grid.Size;
			// Console.WriteLine(row + " " + col);
			grid.reveal(row, col);
			GameCellModel cell = grid.Grid[row, col];
			cell.IsVisited = true;



			// win/loss detection
			if (cell.Live)
			{
				// Console.WriteLine("lost");
				grid.RevealBombs();
				return Json(new { status = "lose" });
			}
			else if (grid.HaveWon())
			{
				// Console.WriteLine("won!");
				return Json(new { status = "win" });
			}


			return PartialView(cell);
		}

		public IActionResult Flag(int buttonNumber)
		{
			GameCellModel cell = grid.Grid[buttonNumber / grid.Size, buttonNumber % grid.Size];
			cell.IsFlagged = !cell.IsFlagged;

			return PartialView("ShowOneButton", cell);
		}
	}
}
