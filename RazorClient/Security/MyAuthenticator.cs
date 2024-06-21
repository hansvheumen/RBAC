using RBAC.Security.Context;

namespace RazorCLient.Security
{
    public class MyAuthenticator : RBAC.Security.Authentication.IAuthenticator
    {
        public Principal? Execute(string username, string password)
        {
            if (username.Length <= 3 || password.Length <= 3) return null;
            return new Principal(username);
        }
    }
}
