using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBAC.Security.Authentication
{
    using RoleCollection = List<String>;
    public interface RoleProvider
    {
        RoleCollection? getRolesForUser(string? username);
    }
}
