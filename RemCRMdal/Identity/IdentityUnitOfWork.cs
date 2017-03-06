using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCRMdal.Identity
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private IdentityContext db;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private ApplicationUserProfileManager userProfileManager;

        public IdentityUnitOfWork(string connectionString)
        {
            db = new IdentityContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            userProfileManager = new ApplicationUserProfileManager(db);
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public IApplicationUserProfileManager UserProfileManager
        {
            get { return userProfileManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    userProfileManager.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
