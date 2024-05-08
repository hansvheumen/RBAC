using RBAC.Security.Context;

namespace Hobby
{
    public class MyAuthenticator : RBAC.Security.Authentication.IAuthenticator
    {
        public Principal? Execute(string username, string password)
        {
            if (username.Length > 3 && password.Length > 3)
            {
                return new Principal(username);
            }
            else
            {
                return null;
            }
        }
    }
}
