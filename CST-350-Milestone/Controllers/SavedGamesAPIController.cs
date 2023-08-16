using CST_350_Milestone.Models;
using CST_350_Milestone.Services;
using Microsoft.AspNetCore.Mvc;

namespace CST_350_Milestone.Controllers
{
    [ApiController]
    [Route("api")]
    public class SavedGamesAPIController : ControllerBase
    {
        public ISavesDataService Saves { get; set; }

        public SavedGamesAPIController(ISavesDataService saves)
        {
            Saves = saves;
        }

        [HttpGet("ShowSavedGames")]
        public ActionResult<IEnumerable<SavesDTO>> ShowSavedGames() 
        {
            return Saves.GetAll();
        }

        [HttpGet("ShowSavedGames/{ID}")]
        public ActionResult<SavesDTO> ShowSavedGames(int ID)
        {
            return Saves.GetOne(ID);
        }

        [HttpGet("DeleteOneGame/{ID}")]
        public ActionResult<IEnumerable<SavesDTO>> DeleteOneGame(int ID) 
        {
            Saves.DeleteOne(ID);
            return Saves.GetAll();
        }
    }
}
