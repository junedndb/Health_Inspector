using LoginandRegisterMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginandRegisterMVC.ViewModels;

namespace LoginandRegisterMVC.Controllers
{
    
    public class HelpController : Controller
    {
        private UserContext context = new UserContext();

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult HelpAsk()
        {
            Help help = new Help();
            return View(help);
        }

        [HttpPost]
        public ActionResult HelpAsk(Help help)
        {
           // string myVar = (string)HttpContext.Session["UserId"];
            help.UserId = (int)HttpContext.Session["Id"];

            if (ModelState.IsValid)
            {
                context.Helps.Add(help);
                context.SaveChanges();

            }
            return View();

        }

        //Help List
        public ActionResult HelpRequests()
        {
            var querylist = context.Helps.ToList();
            return View(querylist);
        }


        public ActionResult Details(int id)
        {

            var help = context.Helps.Find(id);
            return View(help);
        }

        [HttpGet]
        public ActionResult Resolution(int id)
        {
            //var query = context.Helps.Include("ResolveHelp").ToList();

            var resolutionModel = new ResolutionViewModel
            {
                Help = context.Helps.SingleOrDefault(m => m.HelpId == id),
                ResolveHelp = new ResolveHelp()

            };
            resolutionModel.ResolveHelp.HelpId = id;
            return View(resolutionModel);
        }


        [HttpPost]
        public ActionResult Resolution(ResolveHelp resolveHelp)
        {


            if (ModelState.IsValid)
            {
                context.ResolveHelps.Add(resolveHelp);
                context.SaveChanges();
            }
            return View();
        }


        public ActionResult ViewResolutions()
        {

            ViewResolutionsViewModel resolutions = new ViewResolutionsViewModel
            {
                ResolveHelps = context.ResolveHelps.ToList(),
                Helps = context.Helps.ToList()
            };

            return View(resolutions);
        }


        public ActionResult SeeResolutions()
        {
            var query = context.ResolveHelps.Include("Help").ToList();
            return View(query);
        }

        public ActionResult Guide()
        {

            return View();
        }


        
    }
}