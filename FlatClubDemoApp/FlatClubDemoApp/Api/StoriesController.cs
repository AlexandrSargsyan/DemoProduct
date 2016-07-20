using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using DataAccess.Stories;
using DemoApp.Commonm;
using DemoApp.Core.Stories;

namespace FlatClubDemoApp.Api
{
    [Authorize]
    public class StoriesController : ApiController
    {
        private readonly IStoriesService storiesService;

        public StoriesController(IStoriesService storiesService)
        {
            this.storiesService = storiesService;
        }

        [HttpGet]
        public IHttpActionResult GetStories(int page)
        {

            var id = HttpContext.Current.User.Identity.Name;
            var stories = storiesService.GetStories(page, id);
            return Ok(new BaseResponse {Data = stories});
        }

        [HttpPost]
        public IHttpActionResult AddStory(StoriesInfo story)
        {
            var id = HttpContext.Current.User.Identity.Name;
            this.storiesService.AddStory(story,id);
            return Ok(new BaseResponse());
        }

        [HttpGet]
        public IHttpActionResult GetStory(int id)
        {
   
          var result = this.storiesService.GetStory(id);
            return Ok(new BaseResponse {Data = result});
        }
        [HttpPost]
        public IHttpActionResult UpdateStory(StoriesInfo story)
        {

            this.storiesService.UpdateStory(story);
            return Ok(new BaseResponse ());
        }

    }
}
