using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoginandRegisterMVC.Models
{
    public class Appointment
    {
        
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentId { get; set; }

/*        [Required]
        [Display(Name = "Clinic Name")]
*/        public string ClinicName { get; set; }

/*        [Required]
        [Display(Name = "Doctor Name")]
*/        public string DoctorName { get; set; }

/*        [Required]
        [Display(Name = "Doctor Id")]
*/        public int DoctorId { get; set; }


/*        [Required]
        [Display(Name = "Clinic City")]
*/        public string ClinicCity { get; set; }

        [Required]
        [Display(Name = "Date of Appointment")]
        [DataType(DataType.Date)]
        public string DateOfAppointment { get; set; }

/*        [Required]
        [Display(Name = "Patient Name")]
*/        public string PatientName { get; set; }

/*        [Required]
        [Display(Name = "Patient Id")]
*/        public int PatientId { get; set; }

        public string Status { get; set; }
    }
}