using LoginandRegisterMVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;


namespace LoginandRegisterMVC.Controllers
{

    public class UsersController : Controller
    {
        private UserContext db = new UserContext();
        // GET: Users
        [Authorize]
        public ActionResult Index(int? id)
        {
            Session["Id"] = id;
            var num = db.Appointments.Where(a => a.PatientId == id).FirstOrDefault();

            if (num != null)
            {
                List<Appointment> name = new List<Appointment>();

                foreach (var a in db.Appointments.Where(a => a.PatientId == id))
                {
                    string span = (DateTime.Parse(a.DateOfAppointment) - DateTime.Today).TotalDays.ToString();
                    name.Add(a);
                }

                ViewBag.AName = name;
            }

            return View();

        }
        [HttpPost]
        public ActionResult Index(Clinic clinic)
        {

            var data = (from a in db.Clinics
                        where a.Specialization == clinic.Specialization &&
                        a.City == clinic.City
                        select a).ToList();

            return View(data.ToList());
         
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {

            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();

                ViewBag.Message = "New User Registered Successfully !";

                return View();


            }
            return View(user);

        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {

            var IsValidUser = db.Users.Where(a => a.MailId == user.MailId && a.Password == user.Password && a.Role == user.Role).FirstOrDefault();

            if (IsValidUser != null)
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                Session["MailId"] = user.MailId.ToString();

                if (IsValidUser.Role == "Doctor")
                {
                    Session["RoleLogin"] = user.Role;
                    Session["Id"] = IsValidUser.UserId;
                    return RedirectToAction("Index", "Doctor", new { id = IsValidUser.UserId });
                }
                else if (IsValidUser.Role == "Patient")
                {

                    Session["Id"] = IsValidUser.UserId;
                    Session["RoleLogin"] = user.Role;
                    return RedirectToAction("Index", "Users", new { id = IsValidUser.UserId });
                }
                else if (IsValidUser.Role == "Admin")
                {
                    Session["Id"] = IsValidUser.UserId;
                    Session["RoleLogin"] = user.Role;
                    return RedirectToAction("Index", "Adminright", new { id = IsValidUser.UserId });
                }
            }
            else
            {
                ModelState.AddModelError("", "invalid Username or Password or UserType");

            }
            return View();
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult ForgotId()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotId(User user)
        {
            bool IsValid = db.Users.Any(a => a.Fque == user.Fque) &&
                db.Users.Any(a => a.Sque == user.Sque) &&
                db.Users.Any(a => a.Tque == user.Tque);
            if (IsValid)
            {
                var comp = (from a in db.Users
                            where a.Fque == user.Fque && a.Sque == user.Sque && a.Tque == user.Tque
                            select a).FirstOrDefault();
                ViewBag.UName = comp.Username;
                return View();
            }
            else
            {
                ModelState.AddModelError("", "invalid security answer!");

            }
            return View();
        }
        [HttpGet]
        public ActionResult ForgotPassword()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(User user)
        {
            //            var comp = (from a in db.Users where a.MailId == user.MailId select a.Password).First();
            //            var comp = db.Users.Where(a => a.MailId == user.MailId).FirstOrDefault();
            var IsValid = db.Users.Where(a => a.MailId == user.MailId &&
                        a.Fque == user.Fque && a.Sque == user.Sque &&
                        a.Tque == user.Tque && a.Role == user.Role).FirstOrDefault();
            if (IsValid != null)
            {
               
                IsValid.Password = user.Password;
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", "invalid security answer!");

            }
            return View();
        }
    }
}