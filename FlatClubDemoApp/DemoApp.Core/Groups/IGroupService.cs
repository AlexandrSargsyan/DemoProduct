using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApp.Commonm;

namespace DemoApp.Core.Groups
{
   public interface IGroupService
   {
       GroupData GetGroupsForTags(int next,string userId);
       GroupData GetGroupTagsFiltered(GroupData filter);
      GroupResource GetAllGroupes(int page, string userId);
       void JoinToGroup(string userId, int id);
       void AddNewGroup(GroupInfo group, string userId);
   }
}
