using BL.DTO;
using BL.Facades;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserFacade userFacade;

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public LoginController(UserFacade userFacade)
        {
            this.userFacade = userFacade;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AppUserDTO user)
        {
            userFacade.Register(user, user.Password);
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AppUserDTO user)
        {
            var identity = userFacade.Login(user.Email,user.Password);


            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, identity);


            //var username = User.Identity.Name;

            return RedirectToAction("Products", "Home");
        }

      
    }
}