using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginandRegisterMVC.Models
{
    public class DietRecommendation
    {
        public int DietRecommendationId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Recommendation { get; set; }
    }
}