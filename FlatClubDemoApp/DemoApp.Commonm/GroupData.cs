using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Commonm
{
  public  class GroupData
    {
        public int Count { get; set; }
        public int Next { get; set; }
        public string UserId { get; set; }
        public int StoryId { get; set; }
        public List<GroupInfo> Groups { get; set; } 
    }
}
