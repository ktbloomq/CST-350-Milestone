using System.Drawing;
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

		public IActionResult HandleButtonClick(int gridID)
		{
			bool hitMine = false;
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
				hitMine = true;
				grid.RevealBombs();
			} else if (grid.HaveWon())
			{
				return View("WonGame");
			}

			cell.IsVisited = true;
			grid.Grid[row, col] = cell;

			return View("Index", grid);
		}
	}
}
