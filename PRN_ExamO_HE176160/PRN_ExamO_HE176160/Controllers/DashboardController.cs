using Microsoft.AspNetCore.Mvc;
using PRN_ExamO_HE176160.Models;

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
    }
}
