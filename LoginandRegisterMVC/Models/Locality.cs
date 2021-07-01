using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginandRegisterMVC.Models
{
    public class Locality
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int LocalityId { get; set; }
        public string Locality_name { get; set; }

        public ICollection<Clinic> Clinics { get; set; }
    }
}