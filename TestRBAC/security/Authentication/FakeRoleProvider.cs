using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRBAC.security.Authentication
{
    using RBAC.Security.Authentication;
    using RoleCollection = List<String>;
     class FakeRoleProvider : IRoleProvider
    {

        public RoleCollection? getRolesForUser(string? username)
        {
            RoleCollection? roles = null;
            if (username == "admin")
            {
                roles = new RoleCollection { "admin" };
            }
            else if (username == "user")
            {
                roles = new RoleCollection { "user" };
            }
            else if (username == "moderator")
            {
                roles = new RoleCollection { "moderator", "user" };
            }
            else
            {
                roles = null;
            }

            return roles;
        }

    }
}


