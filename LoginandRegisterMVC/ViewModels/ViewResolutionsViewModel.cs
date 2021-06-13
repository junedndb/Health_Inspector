using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoginandRegisterMVC.Models;

namespace LoginandRegisterMVC.ViewModels
{
    public class ViewResolutionsViewModel
    {
        public IEnumerable<Help> Helps { get; set; }
        public IEnumerable<ResolveHelp> ResolveHelps { get; set; }
    }
}