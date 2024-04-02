using RBAC.Security.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBAC.Security.Authentication
{
    public interface IAuthenticator
    {
        Principal? Execute(string username, string password);
    }
}
