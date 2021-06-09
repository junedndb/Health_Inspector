using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoginandRegisterMVC.Models
{
    public class DoctorDetail
    {
 //       [Required]
//        [Display(Name = "DoctorId")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }

        [Required]
        [Display(Name = "Doctor Id")]
        public int DoctorId { get; set; }

        [Required]
        [Display(Name = "Specialization")]
        public string Specialization { get; set; }

        [Required]
        [Display(Name = "Total Clininc")]
        public string TotalClinic { get; set; }

        [Required]
        [Display(Name = "Avalaibility")]
        public string Avalaibility { get; set; }

    }
}