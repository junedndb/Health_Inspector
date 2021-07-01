using LoginandRegisterMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoginandRegisterMVC.Models
{
    public class Speciality
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Speciality_name { get; set; }
        public ICollection<Clinic> Clinics { get; set; }
        public ICollection<DoctorDetail> DoctorDetails { get; set; }
        public ICollection<PatientRecord> PatientRecords { get; set; }

    }
}