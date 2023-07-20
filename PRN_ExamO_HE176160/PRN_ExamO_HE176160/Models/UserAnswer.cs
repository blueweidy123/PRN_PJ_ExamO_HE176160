using System;
using System.Collections.Generic;

namespace PRN_ExamO_HE176160.Models
{
    public partial class UserAnswer
    {
        public int UserAnswerId { get; set; }
        public int? UserId { get; set; }
        public string? ExamId { get; set; }
        public string? QuestionId { get; set; }
        public int? SelectedOptionId { get; set; }

        public int Attemp { get; set; }

        public virtual Exam? Exam { get; set; }
        public virtual Question? Question { get; set; }
        public virtual Option? SelectedOption { get; set; }
        public virtual User? User { get; set; }
    }
}
