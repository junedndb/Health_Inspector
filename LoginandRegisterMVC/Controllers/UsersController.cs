using LoginandRegisterMVC.Models;
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
        public ActionResult Index()
        {
/*            var data = (from a in db.Clinics
                        select a).ToList();
*/            return View();

            //            return View(db.Users.ToList());
        }
        [HttpPost]
        public ActionResult Index(Clinic clinic)
        {

            var data = (from a in db.Clinics
                        where a.ClinicName == clinic.ClinicName
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
            var role = (from a in db.Users where a.MailId == user.MailId select a.Role).First();
            var dt = (from a in db.Users where a.MailId == user.MailId select a).First();
            bool IsValidUser = db.Users.Any(a => a.MailId == user.MailId) && dt.Password == user.Password && role==user.Role ;


                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    Session["MailId"] = user.MailId.ToString();
                    var MailId = (from a in db.Users where a.MailId == user.MailId select a).First();

                    Session["Role"] = MailId.Username;
                    if (MailId.Role == "Doctor")
                    {
                        Session["UserId"] = MailId.UserId;
                        Session["Role"] = MailId.Username;
                        Session["RoleLogin"] = user.Role;
                        return RedirectToAction("Index", "Doctor");
                    }
                    else if (MailId.Role == "Patient")
                    {
                        Session["UserId"] = MailId.UserId;
                        Session["Role"] = MailId.Username;
                        Session["RoleLogin"] = user.Role;
                        return RedirectToAction("Index", "Users");
                    }
                    else if (MailId.Role == "Admin")
                    {
                        Session["UserId"] = MailId.UserId;
                        Session["Role"] = MailId.Username;
                        Session["RoleLogin"] = user.Role;
                        return RedirectToAction("Index", "Adminright");
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
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(User user)
        {
            //            var comp = (from a in db.Users where a.MailId == user.MailId select a.Password).First();
            var comp = db.Users.Where(a => a.MailId == user.MailId).FirstOrDefault();
            comp.Password = user.Password;
            db.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}



