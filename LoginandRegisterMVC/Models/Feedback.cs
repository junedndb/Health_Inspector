﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginandRegisterMVC.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }

        public int QuestionId { get; set; }

        public FeedbackQuestion FeedbackQuestion { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public string Answer { get; set; }
    }
}