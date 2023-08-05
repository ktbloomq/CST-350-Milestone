using NuGet.Protocol;
using System.ComponentModel;

namespace CST_350_Milestone.Models
{
    public class SavesDTO
    {
        [DisplayName("Saved Game ID")]
        public int SaveID { get; set; }
        public int UserID { get; set; }
        public string SaveState { get; set; }
        [DisplayName("Difficulty Level")]
        public int GameDifficulty { get; set; }
        [DisplayName("Size of Board")]
        public int GameSize { get; set; }
        [DisplayName("Date & Time Saved")]
        public DateTime SaveDate { get; set; }

        public SavesDTO(int saveID, int userID, string saveState, DateTime saveDate)
        {
            SaveID = saveID;
            UserID = userID;
            SaveState = saveState;
            SaveDate = saveDate;
            GetDiffAndSize();
        }

        private void GetDiffAndSize()
        {
            string diffString = SaveState.Substring(SaveState.LastIndexOf(":") + 1, 
                SaveState.Length - SaveState.LastIndexOf(":") - 4);
            GameDifficulty = Convert.ToInt32(diffString);

            int sizeIndex = SaveState.IndexOf(":");
            int endSizeIndex = SaveState.IndexOf(",");

            string sizeString = SaveState.Substring(sizeIndex + 1, endSizeIndex - sizeIndex - 1);
            GameSize = Convert.ToInt32(sizeString);
        }
    }
}
