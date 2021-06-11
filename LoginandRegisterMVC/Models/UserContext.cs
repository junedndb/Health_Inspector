using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoginandRegisterMVC.Models
{
    public class UserContext:DbContext
    {
        public UserContext() : base("Name=Dbconfig")
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<DoctorDetail> DoctorDetails { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<ClinicFacilities> ClinicFacilitiess { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}