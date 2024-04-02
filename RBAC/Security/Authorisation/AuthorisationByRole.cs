namespace RBAC.Security.Authorisation
{
    using Security.Context;
    using System.Data;
    using RoleCollection = List<String>;
    using Role = String;
    public class AuthorisationByRole
    {
        public static bool IsAuthorized(Principal? principal, Role role)
        {
            if (principal is null)
            {
                return false;
            }
            else
            {
                return principal.Roles.Contains(role);
            }
        }

        public static bool IsAuthorized(Principal? principal, RoleCollection roles)
        {
            bool isAuthorized = false;
            foreach (Role role in roles)
            {
                if (IsAuthorized(principal, role))
                {
                    isAuthorized = true;
                }
            }
            return isAuthorized;
        }

    }
}
