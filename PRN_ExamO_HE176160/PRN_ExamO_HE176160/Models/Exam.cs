using System;
using System.Collections.Generic;

namespace PRN_ExamO_HE176160.Models
{
    public partial class Exam
    {
        public Exam()
        {
            Questions = new HashSet<Question>();
            Requests = new HashSet<Request>();
            Results = new HashSet<Result>();
            UserAnswers = new HashSet<UserAnswer>();
        }

        public string ExamId { get; set; } = null!;
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? Attemp { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
