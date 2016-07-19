using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using DemoApp.Commonm;

namespace DataAccess.Stories
{
    public class StoriesRepository : IStoriesRepository
    {
        public StoryData GetStories(int page, string userId)
        {
            if (page < 1)
            {
                throw new ArgumentException(nameof(page));
            }
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException(nameof(userId));
            }

            var storyData = new StoryData();
            using (var dbContext = new DemoAppContext())
            {
                var totalRecords = dbContext.Stories.Count();
                storyData.Count = totalRecords;
                if (totalRecords == 0)
                {
                    return storyData;
                }
                var skipRows = (page - 1) * 5;
                var stories = dbContext.Stories.Where(s => s.User.UserId == userId).OrderBy(st => st.PostedOn).Skip(skipRows).Take(5);

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Story, StoriesInfo>().
                        ForMember(m => m.User, opt => opt.Ignore());
                    cfg.CreateMap<Group, GroupInfo>().ForMember(m => m.Users, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();
                var storyInfo = mapper.Map<List<StoriesInfo>>(stories);
                storyData.Stories = storyInfo;

            }
            return storyData;
        }

        public void AddStory(StoriesInfo story, string userId)
        {
            if (story == null)
            {
                throw new ArgumentNullException(nameof(story));
            }
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException(nameof(userId));
            }
            using (var dbContext = new DemoAppContext())
            {
                //Mapper removed from some problems

                var mappedStory = new Story
                {
                    Title = story.Title,
                    Description = story.Description,
                    Content = story.Content,
                    PostedOn = story.PostedOn


                };
                var groupIds = story.Groups.Select(g => g.GroupId);
                var groups = (from g in dbContext.Groups
                              where groupIds.Contains(g.GroupId)
                              select g).ToList();
                mappedStory.User = dbContext.Users.SingleOrDefault(u => u.UserId == story.User.UserId);
                mappedStory.Groups = groups;
                dbContext.Stories.Add(mappedStory);

                dbContext.SaveChanges();
            }


        }

        public StoriesInfo GetStory(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException(nameof(id));
            }
            using (var dbContext = new DemoAppContext())
            {
                var story = dbContext.Stories.SingleOrDefault(s => s.StoryId == id);
                if (story == null) return null;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Story, StoriesInfo>().
                        ForMember(m => m.User, opt => opt.Ignore());
                    cfg.CreateMap<Group, GroupInfo>().ForMember(m => m.Users, opt => opt.Ignore());
                });
                var mapper = config.CreateMapper();

                var storyInfo = mapper.Map<StoriesInfo>(story);
                return storyInfo;

            }
        }

        public void UpdateStory(StoriesInfo story)
        {
            if (story == null)
            {
                throw new ArgumentException(nameof(story));
            }
            using (var dbContext = new DemoAppContext())
            {
                var originalStory = dbContext.Stories.SingleOrDefault(s => s.StoryId == story.StoryId);
                if (originalStory == null)
                {
                    throw new ArgumentNullException(nameof(originalStory));
                }
                var groupIds = story.Groups.Select(g => g.GroupId);
                var groups = (from g in dbContext.Groups
                    where groupIds.Contains(g.GroupId)
                    select g).ToList();
        
                foreach (var g in groups)
                {
                    dbContext.Groups.Attach(g);
                }

                originalStory.Groups.Clear();
                foreach (var g in groups)
                {
                    originalStory.Groups.Add(g);
                }
                originalStory.Content = story.Content;
                originalStory.Description = story.Description;
                originalStory.Title = story.Description;
                
                dbContext.SaveChanges();
            }
        }
    }
}
