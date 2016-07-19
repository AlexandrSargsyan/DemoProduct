using System.Collections.Generic;

namespace DemoApp.Commonm
{
   public class UserInfo
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public List<GroupInfo> Groups { get; set; }
    }
}
