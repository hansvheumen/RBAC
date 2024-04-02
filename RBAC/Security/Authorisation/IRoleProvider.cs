using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBAC.Security.Authorisation
{
    using RoleCollection = List<string>;
    public interface IRoleProvider
    {
        RoleCollection? GetRolesForUser(string? username);
    }
}
