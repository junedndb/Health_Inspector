using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoginandRegisterMVC.Models
{
    public class PatientTreatmentRecord
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }

        [Required]
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }

        [Required]
        [Display(Name = "Symptoms")]
        public string Symptoms { get; set; }

        [Required]
        [Display(Name = "Diagnosis")]
        public string Diagnosis { get; set; }

        [Required]
        [Display(Name = "Treatment Planned")]
        public string TreatmentPlanned { get; set; }

        [Required]
        [Display(Name = "Prescription")]
        public string Prescription { get; set; }

        [Display(Name = "Revisit Required")]
        public string RevisitRequired { get; set; }

        [Display(Name = "Next Revisit Date")]
        [DataType(DataType.Date)]
        public string NextRevisitDate { get; set; }

        [Display(Name = "Next Revisit Time")]
        [DataType(DataType.Time)]
        public string NextRevisitTime { get; set; }

        [Display(Name = "Frequency Revisit")]
        public int FrequencyRevisit { get; set; }

        public int DoctorID { get; set; }

    }
}