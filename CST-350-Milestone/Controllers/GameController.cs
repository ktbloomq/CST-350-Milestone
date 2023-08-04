using CST_350_Milestone.Models;
using CST_350_Milestone.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
			game.RevealBombs();
			return View("Index", game.grid);
		}

		public IActionResult Reveal(int buttonNumber)
		{
			game.grid.ClearFloodFillList();
			int row = buttonNumber / game.grid.Size;
			int col = buttonNumber % game.grid.Size;

			List<int> ids = game.grid.FloodFill(row, col);
			if(ids.Count == 0)
			{
				return Json(new { status = "lose" });
			}
			return Json(ids);
		}

		public IActionResult ShowOneButton(int buttonNumber)
		{
			GameCellModel cell = game.update(buttonNumber);

			// win/loss detection
			if (game.lost)
			{
				// Console.WriteLine("lost");
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

		public IActionResult Save()
		{
			SavesDAO saves = new SavesDAO();
			string json = JsonConvert.SerializeObject(game.grid);
			Console.WriteLine(json);
			saves.save(1, json);
			return View("Index", game.grid);
		}

		[HttpGet]
		[Route("/Game/Load/{save:int}")]
		public IActionResult Load(int save)
		{
			SavesDAO saves = new SavesDAO();
			Console.WriteLine("loading save " + save);
			SavesDTO gameState = saves.getOne(save);
			game = new GameService(gameState.SaveState);
			return View("Index", game.grid);
		}
	}
}
