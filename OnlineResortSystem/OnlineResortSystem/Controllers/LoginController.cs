using OnlineResortSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineResortSystem.Controllers
{
    public class LoginController : Controller
    {
 
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginView loginView)
        {
            if (!ModelState.IsValid)
            {
                return View(loginView); // Return the view with validation errors
            }

            string role = AuthenticateUser(loginView.Username, loginView.Password);

            if (role == "admin")
            {
                return RedirectToAction("Index", "Customers");
            }
            else if (role == "user")
            {
                return RedirectToAction("Index", "Amenities");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Username or Password");
                return View(loginView); // Return the view with error message
            }
        }

        private string AuthenticateUser(string username, string password)
        {
            using (var dbEntities = new ResortDbEntities())
            {
                var user = dbEntities.LoginViews.SingleOrDefault(u => u.Username == username && u.Password == password);
                if (user != null)
                {
                    return user.Role; // Return the role from the database
                }
                else
                {
                    return null; // User not found, authentication failed
                }
            }
        }


    }
}