using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRBAC.security.Mocks
{
    using RBAC.Security.Authorisation;
    using RBAC.Security.Context;
    using RoleCollection = List<string>;
    class MockRoleProviderUser : IRoleProvider
    {
        private MockUsers mockUsers = new MockUsers();  

        public RoleCollection? GetRolesForUser(string? username)
        {       
            RoleCollection? roles = [MockUsers.Role.user.ToString()];
            return roles;
        }

    }
}


