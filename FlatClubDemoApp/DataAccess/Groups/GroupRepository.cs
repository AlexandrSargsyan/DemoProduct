using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DemoApp.Commonm;

namespace DataAccess.Groups
{
    public class GroupRepository : IGroupRepository
    {
        public GroupData GetGroupsForTags(int nextCount,string userId)
        {
            if (nextCount < 1)
            {
                throw new ArgumentException("nextCount");
            }


            var groupData = new GroupData();
            using (var dbContext = new DemoAppContext())
            {
                var user = dbContext.Users.SingleOrDefault(u => u.UserId == userId);
                if (user == null)
                {
                    throw new ArgumentNullException("user");
                }
                var totalRecords = user.Groups.Count;
                groupData.Count = totalRecords;
                if (totalRecords == 0)
                {
                    return groupData;
                }
                var skipRows = (nextCount - 1) * 10;
             
                var groups = user.Groups.OrderBy(k=>k.GroupId).Skip(skipRows).Take(10);
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Group, GroupInfo>().
                        ForMember(m => m.Users, opt => opt.Ignore());
                    cfg.CreateMap<Story, StoriesInfo>().ForMember(m => m.Groups, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();
                var groupInfo = mapper.Map<List<GroupInfo>>(groups);
                groupData.Groups = groupInfo;
                
            }
               return groupData;
        }

        public GroupData GetGroupTagsFiltered(GroupData filter)
        {
            if (filter ==null)
            {
                throw new ArgumentNullException("filter");
            }
            if (filter.Next < 1)
            {
                throw new ArgumentException("filter.Next");
            }
            if (string.IsNullOrEmpty(filter.UserId))
            {
                throw new ArgumentException("filter.UserId");
            }

            var groupData = new GroupData();
            using (var dbContext = new DemoAppContext())
            {
                var user = dbContext.Users.SingleOrDefault(u => u.UserId == filter.UserId);
       
                if (user == null)
                {
                    throw new ArgumentNullException("user");
                }
              
                var list = filter.Groups.Select(g => g.GroupId).ToList();
             
                var totalGroups = from g in user.Groups
                    where !list.Contains(g.GroupId) 
                    orderby g.GroupId
                    select g;
                var totalRecords = totalGroups.Count();
                groupData.Count = totalRecords;
                if (totalRecords == 0)
                {
                    return groupData;
                }
                var skipRows = (filter.Next - 1) * 10;

                var groups = (from g in user.Groups
                             where !list.Contains(g.GroupId)
                             orderby g.GroupId
                             select g).Skip(skipRows).Take(10);
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Group, GroupInfo>().
                        ForMember(m => m.Users, opt => opt.Ignore());
                    cfg.CreateMap<Story, StoriesInfo>().ForMember(m => m.Groups, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();
                var groupInfo = mapper.Map<List<GroupInfo>>(groups);
                groupData.Groups = groupInfo;

            }
            return groupData;
        }

        public GroupResource GetAllGroupes(int page,string userId)
        {
            if (page < 1)
            {
                throw new ArgumentException("page");
            }
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("userId");
            }
            var groupData = new List<GroupViewModel>();
            var groupResource = new GroupResource();
            using (var dbContext = new DemoAppContext())
            {
                groupResource.Count = dbContext.Groups.Count();

                var skipRows = (page - 1)*5;
                var groups =
                    dbContext.Groups
                        .OrderBy(g=>g.GroupId)
                        .Skip(skipRows)
                        .Take(5);
                foreach (var g in groups)
                {
                    var group = new GroupViewModel();
                    group.UserJoined = g.Users.Any(u => u.UserId == userId);
                    group.GroupId = g.GroupId;
                    group.GroupDescription = g.GroupDescription;
                    group.GroupName = g.GroupName;
                    group.UsersCount = g.Users.Count;
                    group.StoriesCount = g.Stories.Count;
                    groupData.Add(group);
                }
                groupResource.Groups = groupData;

            }
            return groupResource;
        }

        public void JoinToGroup(string userId, int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("id");
            }
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("userId");
            }
            using (var dbContext = new DemoAppContext())
            {
                var group = dbContext.Groups.SingleOrDefault(g => g.GroupId == id);
                var user = dbContext.Users.SingleOrDefault(u => u.UserId == userId);
                if (group == null)
                {
                    throw new ArgumentNullException("group");
                }
                if (user == null)
                {
                    throw new ArgumentNullException("user");
                }
                group.Users.Add(user);
                dbContext.SaveChanges();



            }
        }

        public void AddNewGroup(GroupInfo group, string userId)
        {
            if (group == null)
            {
                throw new ArgumentNullException("group");
            }
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("userId");
            }

            using (var dbContext = new DemoAppContext())
            {
                var user = dbContext.Users.SingleOrDefault(u => u.UserId == userId);
                if (user == null)
                {
                    throw new ArgumentNullException("user");
                }

                var groupEntry = new Group
                {
                    GroupName = group.GroupName,
                    GroupDescription = group.GroupDescription,
                    Users = new List<User>(),
                    Stories = new List<Story>()
                    
                    
                };
                groupEntry.Users.Add(user);
               // dbContext.Users.Attach(user);
                dbContext.Groups.Add(groupEntry);
                dbContext.SaveChanges();
            }

        }
    }
}
