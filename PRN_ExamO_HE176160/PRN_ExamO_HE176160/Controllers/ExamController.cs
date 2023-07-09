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
                return RedirectToAction("Login", "Dashboard");
            }
            using (var context = new OnlineEnExamContext())
            {

                bool takenExam = context.Results.Any(r => r.ExamId == ExamId && r.UserId == HttpContext.Session.GetInt32("UId"));
                if (takenExam)
                {
                    return RedirectToAction("PostSubmit", new { ExamId = ExamId });
                }

                Debug.WriteLine("Start Exam......");

                ViewBag.ExamId = ExamId;
                ViewBag.ExamName = context.Exams.FirstOrDefault(e => e.ExamId == ExamId).Description;

                List<Question> questions = context.Questions.Where(q => q.ExamId == ExamId).ToList();
                List<Option> options = context.Options.Where(o => questions.Select(q => q.QuestionId).Contains(o.QuestionId)).ToList();

                var tupleModel = new Tuple<List<Question>, List<Option>>(questions, options);
                return View(tupleModel);
            }
        }

        public IActionResult PostSubmit(String ExamId)
        {
            using (var context = new OnlineEnExamContext())
            { 
                ViewBag.ExamId = ExamId;
                ViewBag.ExamName = context.Exams.FirstOrDefault(e => e.ExamId == ExamId).Description;

                return View();
            }
        }

        [HttpPost]
        public IActionResult SubmitExam(List<UserAnswer> userAnswers)
        {
            Debug.WriteLine("Selected options:");

            using (var context = new OnlineEnExamContext())
            {

                int correctOptionCount = context.Exams
                .Where(e => e.ExamId == userAnswers[0].ExamId)
                .SelectMany(e => e.Questions)
                .SelectMany(q => q.Options)
                .Count(o => o.IsCorrectOption == true);

                Debug.WriteLine($"Number of Correct Options in the Exam: {correctOptionCount}");

                double totalRightAnswer = 0;


                Debug.WriteLine("total correect:" + correctOptionCount);

                foreach (UserAnswer userAnswer in userAnswers)
                {
                    Option selectedOption = context.Options.Find(userAnswer.SelectedOptionId);
                    if (selectedOption != null && selectedOption.IsCorrectOption == true)
                    {
                        totalRightAnswer ++;
                    }

                    // test
                    Debug.WriteLine($"Question ID: {userAnswer.QuestionId}");
                    Debug.WriteLine($"Exam ID: {userAnswer.ExamId}");
                    Debug.WriteLine($"Selected Option ID: {userAnswer.SelectedOptionId}");

                    context.UserAnswers.Add(userAnswer);

                }

                Debug.WriteLine($"answer right: {totalRightAnswer}");
                context.Results.Add(new Result
                {
                    UserId = userAnswers[0].UserId,
                    ExamId = userAnswers[0].ExamId,
                    Marks = (totalRightAnswer/correctOptionCount)*10
                });
                context.SaveChanges();
            }

            return RedirectToAction("PostSubmit", new { ExamId = userAnswers[0].ExamId });
        }

    }
}
