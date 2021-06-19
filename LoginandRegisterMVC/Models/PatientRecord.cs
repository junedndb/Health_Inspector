using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoginandRegisterMVC.Models
{
    public class PatientRecord
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string PatientName { get; set; }

        public string Age { get; set; }

        public string Gender { get; set; }

        public string VisitDate { get; set; }

        public string DoctorName { get; set; }
        public int DoctorID { get; set; }
        public int AppointmentId { get; set; }

        public string DoctorSpecialization { get; set; }

    }
}