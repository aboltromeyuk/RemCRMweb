using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCRMdal.Identity
{
    public class ApplicationUserProfileManager : IApplicationUserProfileManager
    {
        public IdentityContext Database { get; set; }
        public ApplicationUserProfileManager(IdentityContext db)
        {
            Database = db;
        }

        public void Create(ApplicationUserProfile item)
        {
            Database.ApplicatinUserProfiles.Add(item);
            Database.SaveChanges();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
