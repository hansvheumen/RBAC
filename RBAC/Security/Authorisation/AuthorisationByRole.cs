namespace RBAC.Security.Authorisation
{
    using Security.Context;

    public class AuthorisationByRole
    {
        protected AuthorisationByRole() { }

        public static bool IsAuthorized(Principal? principal, Role role)
        {
            return principal?.Roles.Contains(role) ?? false;
        }


        public static bool IsAuthorized(Principal? principal, RoleCollection roles)
        {
            return roles.Any(role => IsAuthorized(principal, role));
        }

    }
}
