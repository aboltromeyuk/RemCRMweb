using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCRMdal.Identity
{
    public interface IApplicationUserProfileManager
    {
        void Create(ApplicationUserProfile item);
    }
}
