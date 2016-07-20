using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Groups;
using DemoApp.Commonm;

namespace DemoApp.Core.Groups
{
  public  class GroupService : IGroupService
    {
      private readonly IGroupRepository groupRepository;

      public GroupService(IGroupRepository groupRepository)
      {
          this.groupRepository = groupRepository;
      }

      public GroupData GetGroupsForTags(int next,string userId)
      {
          return this.groupRepository.GetGroupsForTags(next, userId);
      }

      public GroupData GetGroupTagsFiltered(GroupData filter)
      {
          return this.groupRepository.GetGroupTagsFiltered(filter);
      }

      public GroupResource GetAllGroupes(int page, string userId)
      {
          return this.groupRepository.GetAllGroupes(page,userId);
      }

      public void JoinToGroup(string userId, int id)
      {
          this.groupRepository.JoinToGroup(userId, id);
      }

      public void AddNewGroup(GroupInfo group, string userId)
      {
          this.groupRepository.AddNewGroup(group, userId);
      }
    }
}
