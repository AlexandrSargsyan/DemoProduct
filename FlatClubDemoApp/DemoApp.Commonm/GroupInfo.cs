using System.Collections.Generic;

namespace DemoApp.Commonm
{
    public class GroupInfo
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public string GroupDescription { get; set; }

        public List<StoriesInfo> StoriesInfo { get; set; } 
        public List<UserInfo> Users { get; set; }
   
    }
}