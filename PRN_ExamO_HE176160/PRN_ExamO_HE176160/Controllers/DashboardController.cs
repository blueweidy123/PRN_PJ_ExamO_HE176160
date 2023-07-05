using Microsoft.AspNetCore.Mvc;
using PRN_ExamO_HE176160.Models;
using System.Diagnostics;

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

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            using (var context = new OnlineEnExamContext())
            {
                // Validate the email and password
                var user = context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

                if (user != null)
                {
                    ViewBag.UserL = user.Name;
                    // Authentication successful
                    // Perform any additional actions or redirect to the desired page
                    Debug.WriteLine("User logged in: " + user.ToString());
                    return RedirectToAction("Index", "Dashboard", new { user = user.Name });
                }
            }

            // Authentication failed
            // Add an error message to display in the view
            ModelState.AddModelError("", "Invalid email or password");

            return View();
        }
    }
}
