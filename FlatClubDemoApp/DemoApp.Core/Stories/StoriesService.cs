using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Stories;
using DataAccess.Users;
using DemoApp.Commonm;

namespace DemoApp.Core.Stories
{
   public class StoriesService : IStoriesService
    {
       private readonly IStoriesRepository storiesRepository;
       private readonly IUsersRepository usersRepository;


       public StoriesService(IStoriesRepository storiesRepository,IUsersRepository usersRepository)
       {
           this.storiesRepository = storiesRepository;
           this.usersRepository = usersRepository;
       }

       public StoryData GetStories(int page, string userId)
       {
           return this.storiesRepository.GetStories(page, userId);
       }

       public void AddStory(StoriesInfo story, string userId)
       {
           story.PostedOn = DateTime.Now;
           story.User = this.usersRepository.GetUser(userId);
           this.storiesRepository.AddStory(story,userId);
       }

       public StoriesInfo GetStory(int id)
       {
           return this.storiesRepository.GetStory(id);
       }

       public void UpdateStory(StoriesInfo story)
       {
           this.storiesRepository.UpdateStory(story);
       }
    }
}
