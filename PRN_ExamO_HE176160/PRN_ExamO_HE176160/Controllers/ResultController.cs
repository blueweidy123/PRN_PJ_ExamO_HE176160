using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PRN_ExamO_HE176160.Models;

namespace PRN_ExamO_HE176160.Controllers
{
    public class ResultController : Controller
    {
        public IActionResult ShowResult(String ExamId)
        {
            ViewBag.ExamId = ExamId;
            

            int? userId = HttpContext.Session.GetInt32("UId");

            using (OnlineEnExamContext context = new OnlineEnExamContext())
            {

                decimal? markDecimal = context.Results
    .Where(r => r.UserId == userId && r.ExamId == ExamId)
    .Select(r => r.Marks)
    .FirstOrDefault();

                double mark = markDecimal.HasValue ? Convert.ToDouble(markDecimal.Value) : 0.0;

                ViewBag.ExamName = context.Exams.FirstOrDefault(e => e.ExamId == ExamId).Description;
                ViewBag.Mark = mark;

                var userAnswers = context.UserAnswers
                    .Join(context.Options,
                        ua => ua.SelectedOptionId,
                        o => o.OptionId,
                        (ua, o) => new { UserAnswer = ua, Option = o })
                    .Select(x => new UserAnswer
                    {
                        UserAnswerId = x.UserAnswer.UserAnswerId,
                        UserId = x.UserAnswer.UserId,
                        ExamId = x.UserAnswer.ExamId,
                        QuestionId = x.UserAnswer.QuestionId,
                        SelectedOptionId = x.UserAnswer.SelectedOptionId,
                        SelectedOption = x.Option,
                        Exam = x.UserAnswer.Exam,
                        Question = x.UserAnswer.Question,
                        User = x.UserAnswer.User,
                        Attemp = x.UserAnswer.Attemp
                    })
                .ToList();

                var results = context.Results.Where(r => r.UserId == userId).ToList();
                ViewBag.results = results;

                var tupleModel = new Tuple<List<UserAnswer>, List<Option>>(userAnswers, context.Options.ToList());

                //return View(userAnswers);
                return View(tupleModel);

            }
        }
    }
}
