using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApp.Commonm;

namespace DataAccess.Users
{
   public interface IUsersRepository
    {
        UserInfo GetUser(string userId);
        UserInfo GetUser(UserInfo user);
        bool IsUserExists(string userId);
       bool AddUser(UserInfo model);
    }
}
