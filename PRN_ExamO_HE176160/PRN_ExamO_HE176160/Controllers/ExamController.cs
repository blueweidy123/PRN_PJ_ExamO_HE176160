using Microsoft.AspNetCore.Mvc;
using PRN_ExamO_HE176160.Models;
using System.Diagnostics;
using System.Security.Cryptography;

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
                //var e = context.Exams.FirstOrDefault(e => e.ExamId == ExamId);
                //var r = context.Results.FirstOrDefault(r => r.ExamId == ExamId && r.UserId == HttpContext.Session.GetInt32("UId"));

                var count = context.Results.Where(c => c.UserId == HttpContext.Session.GetInt32("UId") && c.ExamId == ExamId);

                //int attempLeft = e.Attemp - count.Count();

                bool takenExam = context.Results.Any(r => r.ExamId == ExamId && r.UserId == HttpContext.Session.GetInt32("UId"));
                bool requesting = context.Requests.Any(re => re.ExamId == ExamId && re.UserId == HttpContext.Session.GetInt32("UId"));
                if (takenExam)
                {
                    if (!requesting)
                    {
                        return RedirectToAction("PostSubmit", new { ExamId = ExamId });
                    }
                    else if (requesting)
                    {
                        var request = context.Requests.FirstOrDefault(re => re.ExamId == ExamId && re.UserId == HttpContext.Session.GetInt32("UId"));
                        //ViewBag.currentReq = request;
                        if (request.Status != 1)
                        {
                            return RedirectToAction("PostSubmit", new { ExamId = ExamId });
                        }
                    }

                }

                Debug.WriteLine("Start Exam......");

                ViewBag.ExamId = ExamId;
                ViewBag.ExamName = context.Exams.FirstOrDefault(e => e.ExamId == ExamId).Description;

                List<Question> questions = context.Questions.Where(q => q.ExamId == ExamId).ToList();

                //List<Question> rQuestions = new List<Question>();
                //while(questions.Count != 0)
                //{
                //   int r = RandomNumberGenerator.GetInt32(questions.Count);
                //    rQuestions.Add(questions[r]);
                //    questions.Remove(questions[r]);
                //}
                List<Option> options = context.Options.Where(o => questions.Select(q => q.QuestionId).Contains(o.QuestionId)).ToList();

                //List<Option> options = context.Options.Where(o => rQuestions.Select(q => q.QuestionId).Contains(o.QuestionId)).ToList();



                var tupleModel = new Tuple<List<Question>, List<Option>>(questions, options);
                //var tupleModel = new Tuple<List<Question>, List<Option>>(rQuestions, options);
                return View(tupleModel);
            }
        }

        public IActionResult PostSubmit(String ExamId)
        {
            using (var context = new OnlineEnExamContext())
            {
                ViewBag.ExamId = ExamId;
                ViewBag.ExamName = context.Exams.FirstOrDefault(e => e.ExamId == ExamId).Description;
                var requesting = context.Requests.FirstOrDefault(r => r.ExamId == ExamId && r.UserId == HttpContext.Session.GetInt32("UId"));
                var req = requesting?.Status;
                if (req != null)
                {
                    ViewBag.Req = req;
                }
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

                decimal totalRightAnswer = 0;


                Debug.WriteLine("total correect:" + correctOptionCount);

                int? attemp = context.Results
    .Where(r => r.UserId == userAnswers[0].UserId && r.ExamId == userAnswers[0].ExamId)
    .OrderByDescending(r => r.Attemp)
    .FirstOrDefault()?.Attemp;

                //if (attemp == null)
                //{
                //    attemp = 0;
                //}
                int newAttemp = (attemp ?? 0) + 1;

                foreach (UserAnswer userAnswer in userAnswers)
                {
                    Option selectedOption = context.Options.Find(userAnswer.SelectedOptionId);
                    if (selectedOption != null && selectedOption.IsCorrectOption == true)
                    {
                        totalRightAnswer++;
                    }

                    userAnswer.Attemp = newAttemp;
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
                    Marks = (totalRightAnswer / correctOptionCount) * 10,
                    //Attemp = (attemp + 1)
                    Attemp = newAttemp
                });
                var request = context.Requests.FirstOrDefault(re => re.ExamId == userAnswers[0].ExamId && re.UserId == HttpContext.Session.GetInt32("UId"));
                if (request != null)
                {
                    context.Remove(request);
                }
                context.SaveChanges();
            }

            return RedirectToAction("PostSubmit", new { ExamId = userAnswers[0].ExamId });
        }

    }
}
