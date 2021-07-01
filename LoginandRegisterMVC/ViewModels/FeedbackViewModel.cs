using LoginandRegisterMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginandRegisterMVC.ViewModels
{
    public class FeedbackViewModel
    {
        public Feedback Feedback { get; set; }
        public FeedbackQuestion FeedbackQuestion { get; set; }
    }
}