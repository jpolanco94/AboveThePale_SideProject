using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AboveThePale.Models
{
    public class VolunteerInfo
    {
        [Key]
        public int VolunteerInfoID { get; set; }
        public string Description { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Id { get; set; }
    }
}
