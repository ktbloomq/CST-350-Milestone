using CST_350_Milestone.Models;

namespace CST_350_Milestone.Services
{
    public interface ISavesDataService
    {
        public List<SavesDTO> GetAll();
        public SavesDTO GetOne(int id);
        public bool Save(int userId, string gameState);
        public bool DeleteOne(int id);
    }
}
