using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Security;

namespace LoginandRegisterMVC.Models
{
    public class User
    {

//      [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string MailId { get; set; }


        [Required]
        [Display(Name = "First Name")]
        public string firstname { get; set; }


        [Required]
        [Display(Name = "Last Name")]
        public string lastname { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }


        [Required]
        [Display(Name ="Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "DOB")]
        [DataType(DataType.Date)]
        public string Dob { get; set; }

        [Required]
        [Display(Name = "Mobile NUmber")]
        [DataType(DataType.PhoneNumber)]
        public string MNumber { get; set; }

        [Required]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be atleast {2} characters long.", MinimumLength = 8)]
        [MembershipPassword(MinRequiredNonAlphanumericCharacters = 1, MinNonAlphanumericCharactersError = "Your Password needs to contain atleast !,@,#,$ etc.", ErrorMessage = "Your Password must be 8 characters long and contain atleast one symbol(!,@,#,etc).")]
        public string Password { get; set; }


        [Required]
        [Display(Name ="Role")]
        public string Role { get; set; }

        [Required]
        [Display(Name = "What is your height?")]
        public string Fque { get; set; }

        [Required]
        [Display(Name = "What is your weight?")]
        public string Sque { get; set; }

        [Required]
        [Display(Name = "What is your last 4 number of your aadhar?")]
        public string Tque { get; set; }

    }
}