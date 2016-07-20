using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Commonm
{
    public class GroupViewModel
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public string GroupDescription { get; set; }
        public bool  UserJoined { get; set; }
        public int UsersCount { get; set; }
        public int StoriesCount { get; set; }

    }
}
