using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboveThePale.Models
{
    public class EFVolunteerInfoRepository : IVolunteerInfoRepository
    {
        private AppIdentityDbContext context;

        public EFVolunteerInfoRepository(AppIdentityDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<VolunteerInfo> VolunteerInfos => context.VolunteerInfos;
    }
}
