using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboveThePale2.Models
{
    public interface IVolunteerRepository
    {
        public IQueryable<Volunteer> Volunteers { get; }
    }
}
