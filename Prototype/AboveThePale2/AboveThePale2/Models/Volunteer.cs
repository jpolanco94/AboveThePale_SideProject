using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AboveThePale2.Models
{
    public class Volunteer
    {
        [Key]
        public int VolunteerID { get; set; }
        public string VolunteerDescription { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Id { get; set; }
        public string Username { get; set; }
    }
}
