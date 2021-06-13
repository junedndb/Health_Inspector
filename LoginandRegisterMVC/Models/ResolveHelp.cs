using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginandRegisterMVC.Models
{
    public class ResolveHelp
    {
        [Key]
        public int ResolveId { get; set; }

        public int HelpId { get; set; }

        public Help Help { get; set; }

        public string ResolveAnswer { get; set; }

    }
}