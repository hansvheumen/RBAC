using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby
{
    public class MyAuthenticator : RBAC.Security.Authentication.IAuthenticator
    {
        public bool execute(string username, string password)
        {
            if (username.Length > 3 && password.Length > 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
