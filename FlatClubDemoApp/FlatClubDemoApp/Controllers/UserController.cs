using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlatClubDemoApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index(string id)
        {
            return View();
        }
    }
}