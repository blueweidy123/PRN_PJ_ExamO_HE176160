﻿using System;
using System.Collections.Generic;

namespace PRN_ExamO_HE176160.Models
{
    public partial class User
    {
        public User()
        {
            Requests = new HashSet<Request>();
            Results = new HashSet<Result>();
            UserAnswers = new HashSet<UserAnswer>();
        }

        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
