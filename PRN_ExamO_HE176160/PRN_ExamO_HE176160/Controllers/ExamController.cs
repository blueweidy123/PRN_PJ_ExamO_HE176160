using Microsoft.AspNetCore.Mvc;
using PRN_ExamO_HE176160.Models;
using System.Diagnostics;

namespace PRN_ExamO_HE176160.Controllers
{
    public class ExamController : Controller
    {

        private bool IsUserLoggedIn()
        {
            // Check if the user is logged in by verifying the presence of the "Uname" session value
            return !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("Uname"));
        }

        public IActionResult TakeExam(String ExamId)
        {
            if (!IsUserLoggedIn())
            {
                // User is not logged in, redirect to the login page
                return RedirectToAction("Login", "Dashboard");
            }
            using (var context = new OnlineEnExamContext())
            {
                Debug.WriteLine($"Start Exam......");
                ViewBag.ExamId = ExamId;
                ViewBag.ExamName = context.Exams.FirstOrDefault(e => e.ExamId == ExamId).Description;

                List<Question> questions = context.Questions.Where(q => q.ExamId == ExamId).ToList();
                List<Option> options = context.Options.Where(o => questions.Select(q => q.QuestionId).Contains(o.QuestionId)).ToList();

                var tupleModel = new Tuple<List<Question>, List<Option>>(questions, options);
                return View(tupleModel);
            }
        }

        [HttpPost]
        public IActionResult SubmitExam(List<UserAnswer> userAnswers)
        {
            Debug.WriteLine("Selected options:");

            using (var context = new OnlineEnExamContext())
            {
                foreach (UserAnswer userAnswer in userAnswers)
                {
                    // test
                    Debug.WriteLine($"Question ID: {userAnswer.QuestionId}");
                    Debug.WriteLine($"Exam ID: {userAnswer.ExamId}");
                    Debug.WriteLine($"Selected Option ID: {userAnswer.SelectedOptionId}");

                    context.UserAnswers.Add(userAnswer);
                }

                context.SaveChanges();
            }

            return RedirectToAction("Index", "Dashboard");
        }


        //[HttpPost]
        //public IActionResult SubmitExam(List<int> selectedOptions)
        //{

        //    Debug.WriteLine("Selected options:");
        //    foreach (int optionId in selectedOptions)
        //    {
        //        Debug.WriteLine("Selected option: " + optionId);
        //    }



        //    return RedirectToAction("Index", "Dashboard");
        //}


    }
}
