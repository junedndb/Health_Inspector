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
    public class ClinicsController : Controller
    {
        private UserContext db = new UserContext();

        // GET: Clinics
        public ActionResult Index(int? id)
        {
            Clinic clinic = db.Clinics.Find(id);
            var uid = (from a in db.Clinics where a.DoctorId == id select a).ToList();
            var check = (from a in db.Users where a.UserId == id select a).FirstOrDefault();
            Session["Role"] = check.Role;
            Session["Id"] = id;

            if (check.Role.Equals("Admin"))
            {
                return View(db.Clinics.ToList());
            }
            else
            {
                return View(uid.ToList());
            }

         //   return View(uid.ToList());
        }

        // GET: Clinics/Details/5
        public ActionResult Details(int? id,int did)
        {
            var check = (from a in db.Users where a.UserId == did select a).FirstOrDefault();
            Session["Role"] = check.Role;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinic clinic = db.Clinics.Find(id);
            if (clinic == null)
            {
                return HttpNotFound();
            }
            return View(clinic);
        }

        // GET: Clinics/Create
        public ActionResult Create(int? id)
        {
            var check = (from a in db.Users where a.UserId == id select a).FirstOrDefault();
            Session["Role"] = check.Role;

            /*            ViewBag.DoctorId = new SelectList(db.DoctorDetails.Where(a => a.DoctorId == id), "DoctorId", "DoctorId");
            */            /*            ViewBag.DoctorName = new SelectList(db.DoctorDetails.Where(a => a.DoctorId == id), "DoctorName", "DoctorName");
                        */
            //ViewBag.DoctorId = (from a in db.DoctorDetails where a.DoctorId == id select a.DoctorId).FirstOrDefault();

            //ViewBag.DoctorName = (from a in db.DoctorDetails where a.DoctorId == id select a.DoctorName).FirstOrDefault();
            //ViewBag.Facility = db.ClinicFacilitiess.ToList();
            ViewBag.DoctorId = (from a in db.DoctorDetails where a.DoctorId == id select a.DoctorId).FirstOrDefault();
            ViewBag.DoctorName = (from a in db.DoctorDetails where a.DoctorId == id select a.DoctorName).FirstOrDefault();
            ViewBag.Facility = db.ClinicFacilitiess.ToList();
            ViewBag.Locality = new SelectList(db.Localities.ToList(), "LocalityId", "Locality_name");
            ViewBag.Speciality = new SelectList(db.Specialities.ToList(), "Id", "Speciality_name");

            return View();
        }

        // POST: Clinics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //    [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,ClinicName,DoctorName,DoctorId,Facilities,ClinicTiming,AddressFLine,AddressSLine,City,State,ZipCode")] Clinic clinic)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Clinics.Add(clinic);
        //        db.SaveChanges();
        //        return RedirectToAction("Index","Doctor",new { id = clinic.DoctorId});
        //    }

        //    return View(clinic);
        //}

        public ActionResult Create(FormCollection collection, Clinic clinic)
        {
            string facility = collection["facility"];
            clinic.Services = facility;
            db.Clinics.Add(clinic);
            db.SaveChanges();
            return RedirectToAction("Index", "Doctor", new { id = clinic.DoctorId });


        }
        // GET: Clinics/Edit/5
        public ActionResult Edit(int? id,int did)
        {
            var check = (from a in db.Users where a.UserId == did select a).FirstOrDefault();
            Session["Role"] = check.Role;
            ViewBag.Facility = db.ClinicFacilitiess.ToList();
            ViewBag.Locality = new SelectList(db.Localities.ToList(), "LocalityId", "Locality_name");
            ViewBag.Speciality = new SelectList(db.Specialities.ToList(), "Id", "Speciality_name");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinic clinic = db.Clinics.Find(id);
            if (clinic == null)
            {
                return HttpNotFound();
            }
            return View(clinic);
        }

        // POST: Clinics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
    //    [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection, Clinic clinic) 
        {
           
            
                string facility = collection["facility"];
                clinic.Services = facility;
            db.Entry(clinic).State = EntityState.Modified;
            db.SaveChanges();
                return RedirectToAction("Index", "Clinics", new { id = clinic.DoctorId});
           
        }

        // GET: Clinics/Delete/5
        public ActionResult Delete(int? id,int? did)
        {
            var check = (from a in db.Users where a.UserId == did select a).FirstOrDefault();
            Session["Role"] = check.Role;
            ViewBag.Idd = id;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinic clinic = db.Clinics.Find(id);
            db.Clinics.Remove(clinic);
            db.SaveChanges();
            if (clinic == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index", "Clinics", new { id = clinic.DoctorId });
        }

        // POST: Clinics/Delete/5
        [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed()
        {
            Clinic clinic = db.Clinics.Find(ViewBag.Idd);
            db.Clinics.Remove(clinic);
            db.SaveChanges();
            return RedirectToAction("Index" , "Clinics", new { id = clinic.DoctorId});
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
