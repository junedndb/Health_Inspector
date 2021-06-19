using LoginandRegisterMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginandRegisterMVC.Controllers
{
    public class FeedbackController : Controller
    {

        private UserContext context = new UserContext();


        [HttpGet]
        public ActionResult AddQuestion()
        {
            var question = new FeedbackQuestion();
            return View(question);
        }

        [HttpPost]
        public ActionResult AddQuestion(FeedbackQuestion question)
        {

            if (ModelState.IsValid)
            {
                context.FeedbackQuestions.Add(question);
                context.SaveChanges();
            }
            return View(question);
        }


    }
}