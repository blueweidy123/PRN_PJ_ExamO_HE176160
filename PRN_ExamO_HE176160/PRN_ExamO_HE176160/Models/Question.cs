using System;
using System.Collections.Generic;

namespace PRN_ExamO_HE176160.Models
{
    public partial class Question
    {
        public Question()
        {
            Options = new HashSet<Option>();
            UserAnswers = new HashSet<UserAnswer>();
        }

        public string QuestionId { get; set; } = null!;
        public string? ExamId { get; set; }
        public string? QuestionText { get; set; }

        public virtual Exam? Exam { get; set; }
        public virtual ICollection<Option> Options { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
