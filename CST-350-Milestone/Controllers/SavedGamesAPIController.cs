using CST_350_Milestone.Models;
using CST_350_Milestone.Services;
using Microsoft.AspNetCore.Mvc;

namespace CST_350_Milestone.Controllers
{
    [ApiController]
    [Route("api")]
    public class SavedGamesAPIController : ControllerBase
    {

        private static SavesDAO saves = new SavesDAO();

        [HttpGet("ShowSavedGames")]
        public ActionResult<IEnumerable<SavesDTO>> ShowSavedGames() 
        {
            return saves.GetAll();
        }

        [HttpGet("ShowSavedGames/{ID}")]
        public ActionResult<SavesDTO> ShowSavedGames(int ID)
        {
            return saves.getOne(ID);
        }

        [HttpGet("DeleteOneGame/{ID}")]
        public ActionResult<IEnumerable<SavesDTO>> DeleteOneGame(int ID) 
        {
            saves.DeleteOne(ID);
            return saves.GetAll();
        }
    }
}
