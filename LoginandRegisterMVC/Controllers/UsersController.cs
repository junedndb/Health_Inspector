using LoginandRegisterMVC.Models;
using System;
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
            var adate = (from a in db.Appointments select a).First();
            TimeSpan span = DateTime.Parse(adate.DateOfAppointment) - DateTime.Today;
            ViewBag.ADate = span;

            Session["Id"] = id;
/*            var data = (from a in db.Clinics
                        select a).ToList();
*/            return View();

            //            return View(db.Users.ToList());
        }
        [HttpPost]
        public ActionResult Index(Clinic clinic)
        {

            var data = (from a in db.Clinics
                        where a.Facilities == clinic.Facilities
                        select a).ToList();
            
                        return View(data.ToList());
//            return View(clinic);
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
                return RedirectToAction("Login");

            }
            return View(user);

        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
//        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {

            var data = (from a in db.Users where a.MailId == user.MailId && a.Password == user.Password  && a.Role == user.Role select a).First();
//            bool IsValidUser = db.Users.Any(a => a.MailId == user.MailId) && dt.Password == user.Password && role==user.Role ;
            bool IsValidUser = db.Users.Any(a => a.MailId == user.MailId) && db.Users.Any(a => a.Password == user.Password) && db.Users.Any(a => a.Role == user.Role);


            if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    Session["MailId"] = user.MailId.ToString();

                    if (data.Role == "Doctor")
                    {
                        Session["RoleLogin"] = user.Role;
                        Session["Id"] = data.UserId;
//                        return RedirectToAction("Index", "Doctor",new {id = MailId.UserId});
                    return RedirectToAction("Index", "Doctor",new { id = data.UserId});
                    }
                    else if (data.Role == "Patient")
                    {

                    Session["Id"] = data.UserId;
                    Session["RoleLogin"] = user.Role;
                        return RedirectToAction("Index", "Users", new { id = data.UserId });
                    }
                    else if (data.Role == "Admin")
                    {
                    Session["Id"] = data.UserId;
                    Session["RoleLogin"] = user.Role;
                        return RedirectToAction("Index", "Adminright", new { id = data.UserId });
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
            bool IsValid = db.Users.Any(a => a.MailId == user.MailId) &&
                            db.Users.Any(a => a.Fque == user.Fque) &&
                            db.Users.Any(a => a.Sque == user.Sque) &&
                            db.Users.Any(a => a.Tque == user.Tque);
            if (IsValid)
            {
                var comp = (from a in db.Users
                            where a.MailId == user.MailId &&
                            a.Fque == user.Fque && a.Sque == user.Sque && a.Tque == user.Tque
                            select a).FirstOrDefault();
                comp.Password = user.Password;
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