using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginandRegisterMVC.Models
{
    public class FeedbackQuestion
    {
        [Key]
        public int QuestionId { get; set; }
        public string Question { get; set; }
    }
}