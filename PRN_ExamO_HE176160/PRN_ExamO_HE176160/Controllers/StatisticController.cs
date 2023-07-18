using Microsoft.AspNetCore.Mvc;
using PRN_ExamO_HE176160.Models;

namespace PRN_ExamO_HE176160.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult MarkStatistic()
        {
            int c1 = 0, c2 = 0, c3 = 0, c4 = 0, c5 = 0, c6 = 0, c7 = 0, c8 = 0, c9 = 0, c10 = 0;
            using (OnlineEnExamContext context = new OnlineEnExamContext())
            {
                var results = context.Results.ToList();

                foreach (var result in results)
                {
                    if (result.Marks >= 0 && result.Marks <= 1)
                    {
                        c1++;
                    }
                    else if (result.Marks > 1 && result.Marks <= 2)
                    {
                        c2++;
                    }
                    else if (result.Marks > 2 && result.Marks <= 3)
                    {
                        c3++;
                    }
                    else if (result.Marks > 3 && result.Marks <= 4)
                    {
                        c4++;
                    }
                    else if (result.Marks > 4 && result.Marks <= 5)
                    {
                        c5++;
                    }
                    else if (result.Marks > 5 && result.Marks <= 6)
                    {
                        c6++;
                    }
                    else if (result.Marks > 6 && result.Marks <= 7)
                    {
                        c7++;
                    }
                    else if (result.Marks > 7 && result.Marks <= 8)
                    {
                        c8++;
                    }
                    else if (result.Marks > 8 && result.Marks <= 9)
                    {
                        c9++;
                    }
                    else if (result.Marks > 9 && result.Marks <= 10)
                    {
                        c10++;
                    }
                }
                ViewBag.c1 = c1;
                ViewBag.c2 = c2;
                ViewBag.c3 = c3;
                ViewBag.c4 = c4;
                ViewBag.c5 = c5;
                ViewBag.c6 = c6;
                ViewBag.c7 = c7;
                ViewBag.c8 = c8;
                ViewBag.c9 = c9;
                ViewBag.c10 = c10;
            }

            return View();
        }

    }
}
