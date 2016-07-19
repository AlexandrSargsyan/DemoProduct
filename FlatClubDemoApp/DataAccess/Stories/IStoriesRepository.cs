using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApp.Commonm;

namespace DataAccess.Stories
{
   public interface IStoriesRepository
   {
       StoryData GetStories(int page,string userId);
       void AddStory(StoriesInfo story, string userId);
       StoriesInfo GetStory(int id);
       void UpdateStory(StoriesInfo story);
   }
}
