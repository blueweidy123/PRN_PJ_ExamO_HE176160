using System;
using System.Collections.Generic;

namespace PRN_ExamO_HE176160.Models
{
    public partial class Option
    {
        public Option()
        {
            UserAnswers = new HashSet<UserAnswer>();
        }

        public int OptionId { get; set; }
        public string? QuestionId { get; set; }
        public string? OptionText { get; set; }
        public bool? IsCorrectOption { get; set; }

        public virtual Question? Question { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
