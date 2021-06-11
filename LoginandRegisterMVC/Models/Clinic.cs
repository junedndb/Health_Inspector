using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoginandRegisterMVC.Models
{
    public class Clinic
    {
 //       [Required]
 //       [Display(Name = "Clinic Id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [Required]
        [Display(Name = "Clinic Name")]
        public string ClinicName { get; set; }

        [Required]
        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }

        [Required]
        [Display(Name = "Doctor Id")]
        public int DoctorId { get; set; }

        [Required]
        [Display(Name = "Doctor Specialization")]
        public string Specialization { get; set; }


        [Required]
        [Display(Name = "Clinic Facilities")]
        public string Facilities { get; set; }

        [Required]
        [Display(Name = "Clinic Time")]
        public string ClinicTiming { get; set; }

        [Required]
        [Display(Name = "Address line 1")]
        public string AddressFLine { get; set; }

        [Required]
        [Display(Name = "Address line 2")]
        public string AddressSLine { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
    }
}