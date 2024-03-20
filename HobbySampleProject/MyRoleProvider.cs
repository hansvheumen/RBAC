using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby
{
    internal class MyRoleProvider : RBAC.Security.Authentication.IRoleProvider
    {
        public List<string> getRolesForUser(string? username)
        {
            if (username == "Fisherman")
            {
                return ["Player"];
            }
            else
            {
                return ["Admin", "Moderator", "Player"];
            }
        }
    }
}
