using Microsoft.AspNetCore.Mvc;

namespace PRN_ExamO_HE176160.Controllers
{
    public class ExamController : Controller
    {
        public IActionResult TakeExam(String title)
        {
            ViewBag.Title = title;
            return View();
        }
    }
}
