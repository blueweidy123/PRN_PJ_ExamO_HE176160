using Microsoft.AspNetCore.Mvc;
using PRN_ExamO_HE176160.Models;
using System.Diagnostics;
using System;
using System.Web;

namespace PRN_ExamO_HE176160.Controllers
{
    
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            using (OnlineEnExamContext context = new OnlineEnExamContext())
            {
                ViewBag.Exams = context.Exams;

                var Exams = context.Exams.ToList();

                return View(Exams);
            }
        }

        public IActionResult test(User user)
        {
            ViewBag.user = user;
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Uname");
            HttpContext.Session.Remove("UId");
            return RedirectToAction("Index");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            using (var context = new OnlineEnExamContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

                if (user != null)
                {
                    HttpContext.Session.SetString("Uname", user.Name);
                    HttpContext.Session.SetInt32("UId", user.UserId);

                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError("", "Invalid email or password");

            return View();
        }
    }
}
