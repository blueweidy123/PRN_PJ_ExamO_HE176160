using System;
using System.Collections.Generic;

namespace PRN_ExamO_HE176160.Models
{
    public partial class Result
    {
        public int ResultId { get; set; }
        public int? UserId { get; set; }
        public string? ExamId { get; set; }
        public int? Marks { get; set; }

        public virtual Exam? Exam { get; set; }
        public virtual User? User { get; set; }
    }
}
