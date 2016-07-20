using DemoApp.Core;
using System.Web.Http;
using DemoApp.Core.Users;

namespace FlatClubDemoApp.Api
{
    [Authorize]
    public class UsersController : ApiController
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public IHttpActionResult GetUserInfo(string userId)
        {
            return Ok(this.usersService.GetUser(userId));
        }
    }
}
