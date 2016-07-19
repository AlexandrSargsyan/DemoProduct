using FlatClubDemoApp.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DemoApp.Commonm;
using DemoApp.Core;
using DemoApp.Core.Users;

namespace FlatClubDemoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersService usersService;
        // GET: Home

        public HomeController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect($"~/user/my/#/stories");
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


     
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return  RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserInfo { UserId = model.Email, Password = model.Password };
                var logginedUser = usersService.GetUser(user);
                if (logginedUser != null)
                {
                    FormsAuthentication.SetAuthCookie(logginedUser.UserId, false);
                    return RedirectToAction("Index");
                }
                ViewBag.LoginFailed = true;
            }
            return Login();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new UserInfo
                {
                    UserName = model.UserName,
                    Password = model.Password,
                    UserId = model.UserId
                };
                var success =  this.usersService.RegisterNewUser(user);

                
                if (success)
                {
                    ViewBag.SuccessfullyRegistered = true;
                    return View("Login");
                }


                ViewBag.RegistrationFailed = true;
                return View(model);


            }

            return View();
        }
    }
}