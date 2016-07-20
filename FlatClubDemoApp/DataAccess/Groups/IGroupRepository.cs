using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DemoApp.Commonm;

namespace DataAccess.Groups
{
  public  interface IGroupRepository
  {
      GroupData GetGroupsForTags(int nextCount,string userId);
      GroupData GetGroupTagsFiltered(GroupData filter);

        GroupResource GetAllGroupes(int page, string userId);

      void JoinToGroup(string userId, int id);
      void AddNewGroup(GroupInfo group, string userId);
  }
}
