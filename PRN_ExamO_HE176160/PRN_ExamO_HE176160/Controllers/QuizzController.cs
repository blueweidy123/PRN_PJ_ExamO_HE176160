using Microsoft.AspNetCore.Mvc;
using PRN_ExamO_HE176160.Models;
using System.Diagnostics;

namespace PRN_ExamO_HE176160.Controllers
{
    public class QuizzController : Controller
    {
        public IActionResult showQuizz(String ExamId)
        {
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
        public IActionResult SubmitQuizz(string te)
        {
            Debug.WriteLine("received: " + te);
            return Ok("tested ok :))");
        }
    }
}
