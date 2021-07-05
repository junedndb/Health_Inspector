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
    public class PatientTreatmentRecordsController : Controller
    {
        private UserContext db = new UserContext();

        // GET: PatientTreatmentRecords
        public ActionResult Index(int? did)
        {
            var dpr = (from a in db.patientTreatmentRecords where a.DoctorID == did select a).ToList();
            return View(dpr);
        }

        // GET: PatientTreatmentRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientTreatmentRecord patientTreatmentRecord = db.patientTreatmentRecords.Find(id);
            if (patientTreatmentRecord == null)
            {
                return HttpNotFound();
            }
            return View(patientTreatmentRecord);
        }

        // GET: PatientTreatmentRecords/Create
        public ActionResult Create(int? paid, string pname, int? did)
        {
            ViewBag.Id = db.Appointments.Where(a => a.AppointmentId == paid).Select(a => a.PatientId).FirstOrDefault();
           // Session["tId"] = ViewBag.Id;
            ViewBag.Name = pname;
            ViewBag.did = did;
            return View();
        }

        // POST: PatientTreatmentRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
//        [ValidateAntiForgeryToken]
        public ActionResult Create(PatientTreatmentRecord patientTreatmentRecord)
        {
          //  int se = db.patientTreatmentRecords.Select(a => a.Id).FirstOrDefault();
         //   Session["patient"] = se;
            if (ModelState.IsValid)
            {
                db.patientTreatmentRecords.Add(patientTreatmentRecord);
                db.SaveChanges();
                return RedirectToAction("Index","PatientTreatmentRecords",new { did = patientTreatmentRecord.DoctorID});
            }

            return View(patientTreatmentRecord);
        }

        // GET: PatientTreatmentRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientTreatmentRecord patientTreatmentRecord = db.patientTreatmentRecords.Find(id);
            if (patientTreatmentRecord == null)
            {
                return HttpNotFound();
            }
            return View(patientTreatmentRecord);
        }

        // POST: PatientTreatmentRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
//        [ValidateAntiForgeryToken]
        public ActionResult Edit(PatientTreatmentRecord patientTreatmentRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientTreatmentRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patientTreatmentRecord);
        }

        // GET: PatientTreatmentRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientTreatmentRecord patientTreatmentRecord = db.patientTreatmentRecords.Find(id);
            if (patientTreatmentRecord == null)
            {
                return HttpNotFound();
            }
            return View(patientTreatmentRecord);
        }

        // POST: PatientTreatmentRecords/Delete/5
        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientTreatmentRecord patientTreatmentRecord = db.patientTreatmentRecords.Find(id);
            db.patientTreatmentRecords.Remove(patientTreatmentRecord);
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
