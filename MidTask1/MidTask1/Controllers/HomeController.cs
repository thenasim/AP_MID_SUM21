using MidTask1.Models;
using MidTask1.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MidTask1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            Admin a = new Admin();
            return View(a);
        }

        [HttpPost]
        public ActionResult Login(Admin a)
        {
            Database db = new Database();
            if (db.Admins.Login(a))
            {
                TempData["Msg"] = "Logged in successfully!";
                return RedirectToAction("Index");
            }

            TempData["ErrMsg"] = "Username or Password doesn't match!";
            return View();
        }
    }
}