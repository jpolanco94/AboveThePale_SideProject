using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AboveThePale2.Models
{
    public class Marker
    {
        [Key]
        public int MarkerID { get; set; }
        public string Username { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Description { get; set; }
    }
}
