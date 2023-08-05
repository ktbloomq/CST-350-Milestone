using System.ComponentModel;

namespace CST_350_Milestone.Models
{
    public class SavesDTO
    {
        [DisplayName("Saved Game ID")]
        public int SaveID { get; set; }
        public int UserID { get; set; }
        public string SaveState { get; set; }
        [DisplayName("Date & Time Saved")]
        public DateTime SaveDate { get; set; }

        public SavesDTO(int saveID, int userID, string saveState, DateTime saveDate)
        {
            SaveID = saveID;
            UserID = userID;
            SaveState = saveState;
            SaveDate = saveDate;
        }
    }
}
