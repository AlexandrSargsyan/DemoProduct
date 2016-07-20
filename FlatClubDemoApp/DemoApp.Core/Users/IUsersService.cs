using DemoApp.Commonm;

namespace DemoApp.Core.Users
{
  public  interface IUsersService
    {
        UserInfo GetUser(string userId);
        UserInfo GetUser(UserInfo user);
        bool IsUserExists(string userId);
        bool RegisterNewUser(UserInfo model);
    }
}
