using CST_350_Milestone.Models;

namespace CST_350_Milestone.Services
{
    public interface IUsersDataService
    {
        bool FindUserByNameAndPassword(UserModel user);
        bool RegisterUser(UserModel user);
    }
}
