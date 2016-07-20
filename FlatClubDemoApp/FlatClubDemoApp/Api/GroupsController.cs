using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using DemoApp.Commonm;
using DemoApp.Core.Groups;

namespace FlatClubDemoApp.Api
{
    [Authorize]
    public class GroupsController : ApiController
    {
        private readonly IGroupService groupService;

        public GroupsController(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        [HttpGet]
        public IHttpActionResult GetGroupsForTags(int next)
        {
            var id = HttpContext.Current.User.Identity.Name;
            return Ok(new BaseResponse {Data = this.groupService.GetGroupsForTags(next,id)});
        }

        [HttpPost]
        public IHttpActionResult GetGroupTagsFiltered(GroupData filter)
        {
            var id = HttpContext.Current.User.Identity.Name;
            filter.UserId = id;
            GroupData result = this.groupService.GetGroupTagsFiltered(filter);
            return Ok(new BaseResponse { Data = result });

        }

        [HttpGet]
        public IHttpActionResult GetAllGroups(int page)
        {
            var id = HttpContext.Current.User.Identity.Name;
            return Ok(new BaseResponse { Data = this.groupService.GetAllGroupes(page,id)});
        }
        [HttpGet]
        public IHttpActionResult JoinToGroup(int id)
        {
            var userId = HttpContext.Current.User.Identity.Name;
            this.groupService.JoinToGroup(userId, id);

            return Ok(new BaseResponse ());
        }

        [HttpPost]
        public IHttpActionResult CreateNewGroup(GroupInfo group)
        {
            var userId = HttpContext.Current.User.Identity.Name;
            this.groupService.AddNewGroup(group, userId);

            return Ok(new BaseResponse());
        }

    }
}
