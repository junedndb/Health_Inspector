using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LoginandRegisterMVC.Models;

namespace LoginandRegisterMVC.Controllers
{
    [Authorize]
    public class AdminrightController : Controller
    {
        private UserContext db = new UserContext();

        // GET: Adminright
        public ActionResult Index(int? id)
        {
            Session["Id"] = id;
            return View(db.Users.ToList());
        }

        // GET: Adminright/Details/5
        public ActionResult Details(int id)
        {
            Session["Id"] = id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Adminright/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adminright/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
//        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,MailId,firstname,lastname,Username,Dob,MNumber,Password,Role")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        //// GET: Adminright/Edit/5
        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    //Session["Id"] = id;
        //    //if (id == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    //User user = db.Users.Find(id);
        //    //if (user == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    var user = db.Users.Find(id);

        //    return View(user);
        //}

        //// POST: Adminright/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.




        //[HttpPost]
        ////[ValidateAntiForgeryToken]
        //public ActionResult Edit(User user)
        //{
        //    var UserInDb = db.Users.SingleOrDefault(m => m.UserId == user.UserId);
    //        if (ModelState.IsValid)
    //        {

    //            UserInDb.MailId = user.MailId;
    //            UserInDb.firstname = user.firstname;
    //            UserInDb.lastname = user.lastname;
    //            UserInDb.Username = user.Username;
    //            UserInDb.Dob = user.Dob;
    //            UserInDb.MNumber = user.MNumber;
    //            UserInDb.Password = user.Password;
    //            UserInDb.Role = user.Role;

    //            ViewBag.msg = "User Record Updated!";


    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //}
    //    return View(user);
    //}

    // GET: Adminright/Delete/5

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = db.Users.Find(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            var UserInDb = db.Users.SingleOrDefault(m => m.UserId == user.UserId);
            if (ModelState.IsValid)
            {

                UserInDb.MailId = user.MailId;
                UserInDb.firstname = user.firstname;
                UserInDb.lastname = user.lastname;
                UserInDb.Username = user.Username;
                UserInDb.Dob = user.Dob;
                UserInDb.MNumber = user.MNumber;
                UserInDb.Password = user.Password;
                UserInDb.Role = user.Role;
                ViewBag.msg = "User Record Updated!";
                db.SaveChanges();
            }
            return View(user);
        }

        public ActionResult Delete(int id)
        {
            Session["Id"] = id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Adminright/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
