using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemCRMbl.Identity
{
    public interface IServiceCreator
    {
        IUserService CreateUserService(string connection);
    }
}
