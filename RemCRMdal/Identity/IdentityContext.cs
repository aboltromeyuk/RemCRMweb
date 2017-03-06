using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCRMdal.Identity
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(string conectionString) : base(conectionString) { }

        public DbSet<ApplicationUserProfile> ApplicatinUserProfiles { get; set; }
    }
}
