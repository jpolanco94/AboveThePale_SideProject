using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboveThePale.Models
{
    public interface IVolunteerInfoRepository
    {
        IQueryable<VolunteerInfo> VolunteerInfos { get; }
    }
}
