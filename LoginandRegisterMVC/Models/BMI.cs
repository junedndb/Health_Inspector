using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginandRegisterMVC.Models
{
    public class BMI
    {
        public int BMIId { get; set; }

        [Required]
        [Display(Name ="Height (In Feet)")]
        [Range(1, int.MaxValue,ErrorMessage = "The Height field is required.")]
        public double  Height { get; set; }

        [Required]
        [Display(Name = "Weight (In Kg)")]
        [Range(1, int.MaxValue, ErrorMessage = "The Weight field is required.")]
        public double  Weight { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public double BMIResult { get; set; }
    }
}