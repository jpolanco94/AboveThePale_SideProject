using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboveThePale2.Models
{
    public class EFVolunteerRepository : IVolunteerRepository
    {
        private AppIdentityDbContext context;

        public EFVolunteerRepository(AppIdentityDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Volunteer> Volunteers => context.Volunteers;
    }
}
