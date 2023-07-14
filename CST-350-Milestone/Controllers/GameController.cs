using CST_350_Milestone.Models;
using Microsoft.AspNetCore.Mvc;

namespace CST_350_Milestone.Controllers
{
	public class GameController : Controller
	{
		public IActionResult Index(int difficulty, int size)
		{
			if (size == 0 && difficulty == 0)
			{
				size = 8;
				difficulty = 1;
			}
			List<GameCellModel> cells = new List<GameCellModel>();

			for (int i = 0; i < size * 10; i++)
			{
				cells.Add(new GameCellModel(i));
			}
			return View(cells);
		}
	}
}
