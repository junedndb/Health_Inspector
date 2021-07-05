﻿using System;
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
    public class DoctorController : Controller
    {
        private UserContext db = new UserContext();

        // GET: Doctor
        public ActionResult Index(int? id)
        {
            DoctorDetail doctorDetail = db.DoctorDetails.Find(id);
            var uid = (from a in db.DoctorDetails where a.DoctorId==id select a).ToList();
            var check = (from a in db.Users where a.UserId == id select a).FirstOrDefault();

            Session["Id"] = id;
            Session["Role"] = check.Role;



            bool IsDoctor = db.DoctorDetails.Any(a => a.DoctorId == id);
            ViewBag.check = IsDoctor;
            if (IsDoctor)
            {
                Session["Available"] = "Yes";
            }
            else
            {
                Session["Available"] = "No";
            }

            if (check.Role.Equals("Admin"))
            {
                return View(db.DoctorDetails.ToList());
            }
            else if (check.Role.Equals("Doctor"))
            {

                return View(uid.ToList());
            }
            return View();

            //      return View(db.DoctorDetails.ToList());
        }

        // GET: Doctor/Details/5
        public ActionResult Details(int? id, int? did)
        {
            var check = (from a in db.Users where a.UserId == did select a).FirstOrDefault();
            Session["Role"] = check.Role;
            Session["Id"] = did;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorDetail doctorDetail = db.DoctorDetails.Find(id);
            if (doctorDetail == null)
            {
                return HttpNotFound();
            }
            return View(doctorDetail);
        }

        // GET: Doctor/Create
        public ActionResult Create(int? id)
        {
            ViewBag.DoctorId = new SelectList(db.Users.Where(a => a.UserId == id), "UserId", "UserId");
            var check = (from a in db.Users where a.UserId == id select a).FirstOrDefault();
            Session["Role"] = check.Role;
            Session["Id"] = id;
            ViewBag.Speciality = new SelectList(db.Specialities.ToList(), "Id", "Speciality_name");
            var clinicname = from s in db.Clinics
                             select new { Clinic_Id = s.Id, ClinicName = s.ClinicName };
            ViewBag.c1 = new SelectList(clinicname, "ClinicName", "ClinicName");

            return View();
        }

        // POST: Doctor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection, DoctorDetail doctorDetail)
        {

            for (int i = 0; i < doctorDetail.NumberClinic.Count(); i++)
            {
                doctorDetail.TotalClinic += "," + doctorDetail.NumberClinic[i];
            }

            var stj = doctorDetail.TotalClinic;
            db.DoctorDetails.Add(doctorDetail);
            db.SaveChanges();
            return RedirectToAction("Index", "Doctor", new { id = doctorDetail.DoctorId });
        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(int? id,int? did)
        {
            var check = (from a in db.Users where a.UserId == did select a).FirstOrDefault();
            Session["Role"] = check.Role;
            Session["Id"] = did;
            ViewBag.Speciality = new SelectList(db.Specialities.ToList(), "Id", "Speciality_name");
            var clinicname = from s in db.Clinics
                             select new { Clinic_Id = s.Id, ClinicName = s.ClinicName };
            ViewBag.c1 = new SelectList(clinicname, "ClinicName", "ClinicName");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorDetail doctorDetail = db.DoctorDetails.Find(id);
            if (doctorDetail == null)
            {
                return HttpNotFound();
            }
            return View(doctorDetail);
        }

        // POST: Doctor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
//        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection, DoctorDetail doctorDetail)
        {
            for (int i = 0; i < doctorDetail.NumberClinic.Count(); i++)
            {
                doctorDetail.TotalClinic += "," + doctorDetail.NumberClinic[i];
            }

            var stj = doctorDetail.TotalClinic;
            db.Entry(doctorDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Doctor",new { id = doctorDetail.DoctorId});
            
            
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(int? id,int?did)
        {
            var check = (from a in db.Users where a.UserId == did select a).FirstOrDefault();
            Session["Role"] = check.Role;
            Session["Id"] = did;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorDetail doctorDetail = db.DoctorDetails.Find(id);
            db.DoctorDetails.Remove(doctorDetail);
            db.SaveChanges();
            if (doctorDetail == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index", "Doctor", new { id = id });
        }

        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            DoctorDetail doctorDetail = db.DoctorDetails.Find(id);
            db.DoctorDetails.Remove(doctorDetail);
            db.SaveChanges();
            return RedirectToAction("Index","Doctor",new { id = id});
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
    

