﻿using Microsoft.AspNetCore.Mvc;
using PRN_ExamO_HE176160.Models;

namespace PRN_ExamO_HE176160.Controllers
{
    public class ExamController : Controller
    {
        public IActionResult TakeExam(String ExamId)
        {
            ViewBag.ExamId = ExamId;



            using (var context = new OnlineEnExamContext())
            {
                List<Question> questions = context.Questions.Where(q => q.ExamId == ExamId).ToList();

                List<Option> options = context.Options.Where(o => questions.Select(q => q.QuestionId).Contains(o.QuestionId)).ToList();

                var tupleModel = new Tuple<List<Question>, List<Option>>(questions, options);
                return View(tupleModel);
            }


        }

    }
}