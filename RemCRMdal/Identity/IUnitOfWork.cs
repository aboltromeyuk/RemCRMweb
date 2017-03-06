using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCRMdal.Identity
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IApplicationUserProfileManager UserProfileManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}
