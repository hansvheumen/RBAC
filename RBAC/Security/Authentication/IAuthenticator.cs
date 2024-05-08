using RBAC.Security.Context;

namespace RBAC.Security.Authentication
{
    public interface IAuthenticator
    {
        Principal? Execute(string username, string password);
    }
}
