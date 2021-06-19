using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginandRegisterMVC.Models
{
    public class Help
    {
        [Key]
        public int HelpId { get; set; }
        public string Issue { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Description { get; set; }
    }
}