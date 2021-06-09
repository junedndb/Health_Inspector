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
    public class AppointmentsController : Controller
    {
        private UserContext db = new UserContext();

        // GET: Appointments
        public ActionResult Index(int? id)
        {
            var da = (from a in db.Appointments where a.DoctorId == id select a).ToList();
            var pa = (from a in db.Appointments where a.PatientId == id select a).ToList();
            var das = (from a in db.Users where a.UserId == id select a).FirstOrDefault();

            Session["Id"] = id;
            
            Session["Role"] = das.Role;
            if (Session["Role"].Equals("Doctor"))
            {
                return View(da);

            }
            else if (Session["Role"].Equals("Patient"))
            {
                return View(pa);

            }
            else 
            {
                return View(db.Appointments.ToList());
            }
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id,int? uid)
        {
            var das = (from a in db.Users where a.UserId == uid select a).FirstOrDefault();

            Session["Role"] = das.Role;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        public ActionResult BookAppointment(int? did, int? uid, Appointment appointment)
        {
            var ddata = (from a in db.Clinics where a.DoctorId == did select a).FirstOrDefault();
            var udata = (from a in db.Users where a.UserId == uid select a).FirstOrDefault();
            appointment = new Appointment
            {
                ClinicName = ddata.ClinicName,
                DoctorName = ddata.DoctorName,
                DoctorId = ddata.DoctorId,
                ClinicCity = ddata.City,
                PatientName = udata.firstname +" "+udata.lastname,
                PatientId = udata.UserId,
                Status = "Pending",
                DateOfAppointment = "2021-06-05"
            };
            db.Appointments.Add(appointment);
            db.SaveChanges();

            return RedirectToAction("Create");
        }

        public ActionResult BackToList()
        {
            return RedirectToAction("Index");
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {


            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
    //    [ValidateAntiForgeryToken]
        public ActionResult Create(Appointment appointment)
        {
            /*            if (ModelState.IsValid)
                        {

            */
            var last = (from a in db.Appointments select a).OrderByDescending(a => a.AppointmentId).First().AppointmentId;
            var app = (from a in db.Appointments where a.AppointmentId == last select a).FirstOrDefault();
            app.DateOfAppointment = appointment.DateOfAppointment;

            db.SaveChanges();


            return RedirectToAction("Index","Appointments",new { id = app.PatientId});
/*            }
*/
 //           return View(appointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id, int? uid)
        {
            var das = (from a in db.Users where a.UserId == uid select a).FirstOrDefault();

            Session["Role"] = das.Role;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
      //  [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentId,ClinicName,DoctorName,DoctorId,ClinicCity,DateOfAppointment,PatientName,PatientId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id,int?uid)
        {
            var das = (from a in db.Users where a.UserId == uid select a).FirstOrDefault();
            Session["Role"] = das.Role;
            Session["Id"] = uid;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
       // [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

/*        public ActionResult Approve()
        {
            return View();
        }
*/        
        public ActionResult Approve(int? id, int? uid)
        {
            var approve = (from a in db.Appointments where a.AppointmentId == id select a).FirstOrDefault();
            approve.Status = "Approve";
            db.SaveChanges();
            return RedirectToAction("Index","Appointments",new { id= uid});
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
