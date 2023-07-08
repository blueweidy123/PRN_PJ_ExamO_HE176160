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

        //[HttpPost]
        //public IActionResult SubmitExam(List<UserAnswer> userAnswers)
        //{
        //    Debug.WriteLine("Selected options:");

        //    using (var context = new OnlineEnExamContext())
        //    {
        //        foreach (UserAnswer userAnswer in userAnswers)
        //        {
        //            // test
        //            Debug.WriteLine($"Question ID: {userAnswer.QuestionId}");
        //            Debug.WriteLine($"Exam ID: {userAnswer.ExamId}");
        //            Debug.WriteLine($"Selected Option ID: {userAnswer.SelectedOptionId}");

        //            context.UserAnswers.Add(userAnswer);
        //        }

        //        context.SaveChanges();
        //    }

        //    return RedirectToAction("Index", "Dashboard");
        //}

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

            return RedirectToAction("Index", "Dashboard");
        }

        private void CalculateAndSaveMark(OnlineEnExamContext context, UserAnswer userAnswer)
        {
            // Get the exam associated with the user's answer
            var exam = context.Exams.SingleOrDefault(e => e.ExamId == userAnswer.ExamId);

            if (exam == null)
            {
                // Handle the case where the exam is not found
                // You can throw an exception or return an error message
                return;
            }

            // Get all the options for the exam
            var options = context.Options.Where(o => o.Question.ExamId == exam.ExamId).ToList();

            // Get the correct options count for the exam
            int correctOptionsCount = options.Count(o => o.IsCorrectOption == true);

            // Get the user's selected options count for the question
            int userSelectedOptionsCount = userAnswer.SelectedOptionId != null ? 1 : 0;

            // Calculate the mark
            double mark = userSelectedOptionsCount <= 1 ? (double)userSelectedOptionsCount / correctOptionsCount : 0;

            // Create a new result object
            var result = new Result
            {
                UserId = userAnswer.UserId,
                ExamId = userAnswer.ExamId,
                Marks = mark
            };

            context.Results.Add(result);
        }

    }
}
