using Microsoft.AspNetCore.Mvc;
using PRN_ExamO_HE176160.Models;
using System.Diagnostics;
using System;
using System.Web;

namespace PRN_ExamO_HE176160.Controllers
{

    public class DashboardController : Controller
    {
        public IActionResult Index(string search, string action)
        {


            using (OnlineEnExamContext context = new OnlineEnExamContext())
            {
                ViewBag.Exams = context.Exams;

                var Exams = context.Exams.ToList();

                if (action == "search" && search != null)
                {
                    Exams = Exams.Where(e => e.ExamId.ToLower().Contains(search.ToLower())).ToList();
                }
                else if (search == null)
                {
                    Exams = context.Exams.ToList();
                }

                return View(Exams);
            }
        }

        public IActionResult Admin()
        {
            using (OnlineEnExamContext context = new OnlineEnExamContext())
            {
                var reqs = context.Requests.ToList();
                var user = context.Users.ToList();
                ViewBag.reqs = reqs;
                ViewBag.users = user;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Request(int uId, string eId)
        {
            using (OnlineEnExamContext context = new OnlineEnExamContext())
            {
                bool requesting = context.Requests.Any(re => re.ExamId == eId && re.UserId == uId);

                if (!requesting)
                {
                    context.Add(new Request
                    {
                        UserId = uId,
                        ExamId = eId,
                        Status = 0
                    });
                    context.SaveChanges();
                }

            }
            //Debug.WriteLine(""+uId+","+eId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Accept(int requestId)
        {
            using (OnlineEnExamContext context = new OnlineEnExamContext())
            {
                var req = context.Requests.FirstOrDefault(re => re.RequestId == requestId);

                if (req != null)
                {
                    req.Status = 1;
                    context.SaveChanges();
                }
            }

            return RedirectToAction("Admin");
        }

        [HttpPost]
        public IActionResult Reject(int requestId)
        {
            using (OnlineEnExamContext context = new OnlineEnExamContext())
            {
                var req = context.Requests.FirstOrDefault(re => re.RequestId == requestId);

                if (req != null)
                {
                    req.Status = -1;
                    context.SaveChanges();
                }
            }

            return RedirectToAction("Admin");
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
