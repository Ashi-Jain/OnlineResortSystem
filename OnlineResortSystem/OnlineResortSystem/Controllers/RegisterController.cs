using OnlineResortSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineResortSystem.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginView loginView)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    LoginView newUser = new LoginView
                    {
                        Username = loginView.Username,
                        Password = loginView.Password,
                        Role = loginView.Role
                    };

                    using(var dbEntities = new ResortDbEntities())
                    {
                        dbEntities.LoginViews.Add(newUser);
                        dbEntities.SaveChanges();
                    }
                    return RedirectToAction("Index", "Login");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("","An error occured while registering: "+ex.Message);
                }
            }
            return View(loginView);
        }
    }
}