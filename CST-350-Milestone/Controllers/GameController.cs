using CST_350_Milestone.Models;
using Microsoft.AspNetCore.Mvc;

namespace CST_350_Milestone.Controllers
{
    public class GameController : Controller
    {
        static public GameBoard board = new(10);
        static List<GameCell> buttons = new();
        decimal difficulty = 10.0m;

        public IActionResult Index()
        {
            //sets up gameboard class
            board.Difficulty = difficulty;
            board.ClearBombs();
            board.SetupLiveNeighbors();
            board.CalculateLiveNeighbors();


            //Generate grid
            UpdateButtons();

            return View("Index", buttons);
        }

        public IActionResult HandleButtonClick(int buttonPosition)
        {
            //turns the button position into usuable values for the gameboard class
            int r = buttonPosition;
            int c = buttonPosition;

            //recursive method for floodfilling
            board.FloodFill(r, c);

            //clears the array list of buttons and generates updated values
            buttons.Clear();
            UpdateButtons();
            
            return View("Index", buttons);
		}
        public void UpdateButtons()  //Method to update the grid of buttons in the html of game view
        {
            buttons.Clear();
            for (int row = 0; row < board.Grid.GetLength(0); row++)
            {
                for (int col = 0; col < board.Grid.GetLength(1); col++)
                {
                    bool visited = board.Grid[row, col].IsVisited;
                    bool live = board.Grid[row, col].Live;
                    int nearbyBombs = board.Grid[row, col].LiveNeighbors;
                    bool flagged = board.Grid[row, col].IsFlagged;
                    buttons.Add(new GameCell(row, col, visited, live, nearbyBombs, flagged));
                }
            }
        }
	}
}


