using System;
using System.Collections.Generic;

namespace DemoApp.Commonm
{
 public   class StoriesInfo
    {
        public int StoryId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
  
        public string Content { get; set; }
 
        public DateTime PostedOn { get; set; }


        public UserInfo User { get; set; }

        public List<GroupInfo> Groups { get; set; }

      
    }
}
