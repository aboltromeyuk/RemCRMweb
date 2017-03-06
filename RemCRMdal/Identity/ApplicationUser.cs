using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCRMdal.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ApplicationUserProfile UserProfile { get; set; }
    }
}
