using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboveThePale2.Models
{
    public class EFMarkerRepository : IMarkerRepository
    {
        private AppIdentityDbContext context;

        public EFMarkerRepository(AppIdentityDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Marker> Markers => context.Markers;
    }
}
