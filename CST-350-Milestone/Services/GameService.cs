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

		public GameService()
		{
			grid = JsonConvert.DeserializeObject<GameGridModel>("{\"Size\":8,\"Grid\":[[{\"Id\":0,\"Row\":0,\"Column\":0,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":1,\"Row\":0,\"Column\":1,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":2,\"Row\":0,\"Column\":2,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":3,\"Row\":0,\"Column\":3,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":4,\"Row\":0,\"Column\":4,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":5,\"Row\":0,\"Column\":5,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":1,\"IsFlagged\":false},{\"Id\":6,\"Row\":0,\"Column\":6,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":1,\"IsFlagged\":false},{\"Id\":7,\"Row\":0,\"Column\":7,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":1,\"IsFlagged\":false}],[{\"Id\":8,\"Row\":1,\"Column\":0,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":9,\"Row\":1,\"Column\":1,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":10,\"Row\":1,\"Column\":2,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":11,\"Row\":1,\"Column\":3,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":12,\"Row\":1,\"Column\":4,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":13,\"Row\":1,\"Column\":5,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":2,\"IsFlagged\":false},{\"Id\":14,\"Row\":1,\"Column\":6,\"IsVisited\":false,\"Live\":true,\"LiveNeighbors\":9,\"IsFlagged\":false},{\"Id\":15,\"Row\":1,\"Column\":7,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":2,\"IsFlagged\":false}],[{\"Id\":16,\"Row\":2,\"Column\":0,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":17,\"Row\":2,\"Column\":1,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":18,\"Row\":2,\"Column\":2,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":19,\"Row\":2,\"Column\":3,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":20,\"Row\":2,\"Column\":4,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":21,\"Row\":2,\"Column\":5,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":2,\"IsFlagged\":false},{\"Id\":22,\"Row\":2,\"Column\":6,\"IsVisited\":false,\"Live\":true,\"LiveNeighbors\":9,\"IsFlagged\":false},{\"Id\":23,\"Row\":2,\"Column\":7,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":3,\"IsFlagged\":false}],[{\"Id\":24,\"Row\":3,\"Column\":0,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":25,\"Row\":3,\"Column\":1,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":26,\"Row\":3,\"Column\":2,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":1,\"IsFlagged\":false},{\"Id\":27,\"Row\":3,\"Column\":3,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":1,\"IsFlagged\":false},{\"Id\":28,\"Row\":3,\"Column\":4,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":1,\"IsFlagged\":false},{\"Id\":29,\"Row\":3,\"Column\":5,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":1,\"IsFlagged\":false},{\"Id\":30,\"Row\":3,\"Column\":6,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":2,\"IsFlagged\":false},{\"Id\":31,\"Row\":3,\"Column\":7,\"IsVisited\":false,\"Live\":true,\"LiveNeighbors\":9,\"IsFlagged\":false}],[{\"Id\":32,\"Row\":4,\"Column\":0,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":33,\"Row\":4,\"Column\":1,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":34,\"Row\":4,\"Column\":2,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":1,\"IsFlagged\":false},{\"Id\":35,\"Row\":4,\"Column\":3,\"IsVisited\":false,\"Live\":true,\"LiveNeighbors\":9,\"IsFlagged\":true},{\"Id\":36,\"Row\":4,\"Column\":4,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":1,\"IsFlagged\":false},{\"Id\":37,\"Row\":4,\"Column\":5,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":38,\"Row\":4,\"Column\":6,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":1,\"IsFlagged\":false},{\"Id\":39,\"Row\":4,\"Column\":7,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":1,\"IsFlagged\":false}],[{\"Id\":40,\"Row\":5,\"Column\":0,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":1,\"IsFlagged\":false},{\"Id\":41,\"Row\":5,\"Column\":1,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":1,\"IsFlagged\":false},{\"Id\":42,\"Row\":5,\"Column\":2,\"IsVisited\":true,\"Live\":false,\"LiveNeighbors\":2,\"IsFlagged\":false},{\"Id\":43,\"Row\":5,\"Column\":3,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":1,\"IsFlagged\":false},{\"Id\":44,\"Row\":5,\"Column\":4,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":1,\"IsFlagged\":false},{\"Id\":45,\"Row\":5,\"Column\":5,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":46,\"Row\":5,\"Column\":6,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":47,\"Row\":5,\"Column\":7,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false}],[{\"Id\":48,\"Row\":6,\"Column\":0,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":1,\"IsFlagged\":false},{\"Id\":49,\"Row\":6,\"Column\":1,\"IsVisited\":false,\"Live\":true,\"LiveNeighbors\":9,\"IsFlagged\":false},{\"Id\":50,\"Row\":6,\"Column\":2,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":2,\"IsFlagged\":false},{\"Id\":51,\"Row\":6,\"Column\":3,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":1,\"IsFlagged\":false},{\"Id\":52,\"Row\":6,\"Column\":4,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":53,\"Row\":6,\"Column\":5,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":54,\"Row\":6,\"Column\":6,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":55,\"Row\":6,\"Column\":7,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false}],[{\"Id\":56,\"Row\":7,\"Column\":0,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":1,\"IsFlagged\":false},{\"Id\":57,\"Row\":7,\"Column\":1,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":2,\"IsFlagged\":false},{\"Id\":58,\"Row\":7,\"Column\":2,\"IsVisited\":false,\"Live\":true,\"LiveNeighbors\":9,\"IsFlagged\":false},{\"Id\":59,\"Row\":7,\"Column\":3,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":1,\"IsFlagged\":false},{\"Id\":60,\"Row\":7,\"Column\":4,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":61,\"Row\":7,\"Column\":5,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":62,\"Row\":7,\"Column\":6,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false},{\"Id\":63,\"Row\":7,\"Column\":7,\"IsVisited\":false,\"Live\":false,\"LiveNeighbors\":0,\"IsFlagged\":false}]],\"Difficulty\":10.0}");
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
