using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Commonm
{
  public  class GroupResource
    {
      public GroupResource()
      {
         this.Groups = new List<GroupViewModel>();
      }
        public List<GroupViewModel> Groups { get; set; }
        public int Count { get; set; }
    }
}
