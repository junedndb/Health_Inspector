using LoginandRegisterMVC.Models;
using LoginandRegisterMVC.ViewModels;
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


        public ActionResult QuestionList()
        {
            var list = context.FeedbackQuestions.ToList();
            return View(list);
        }


        [HttpGet]
        public ActionResult QuestionDelete(int? id)
        {
            var question = context.FeedbackQuestions.Where(q => q.QuestionId == id).SingleOrDefault();
            return View(question);
        }

        [HttpPost]
        public ActionResult QuestionDelete(int id)
        {
            var questionInDb = context.FeedbackQuestions.Where(q => q.QuestionId == id).SingleOrDefault();
            context.FeedbackQuestions.Remove(questionInDb);
            context.SaveChanges();
            return View();
        }

        public ActionResult QuestionsList()
        {
            var list = context.FeedbackQuestions.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult AddFeedback(int id)
        {
            FeedbackViewModel viewModel = new FeedbackViewModel
            {
                Feedback = new Feedback(),
                FeedbackQuestion = context.FeedbackQuestions.SingleOrDefault(m => m.QuestionId == id),
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddFeedback(FeedbackViewModel viewModel)
        {
            viewModel.Feedback.UserId = (int)HttpContext.Session["Id"];
            viewModel.Feedback.QuestionId = viewModel.FeedbackQuestion.QuestionId;
            if (ModelState.IsValid)
            {
                ViewBag.msg = "Feedback Submitted!";
                context.Feedbacks.Add(viewModel.Feedback);
                context.SaveChanges();
            }
            return View();
        }



    }
}