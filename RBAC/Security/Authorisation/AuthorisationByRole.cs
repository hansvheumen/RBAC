namespace RBAC.Security.Authorisation
{
    using Security.Context;
    using System.Data;
    using RoleCollection = List<String>;
    public class AuthorisationByRole
    {
        private readonly SecurityContext context;

        public AuthorisationByRole(SecurityContext context)
        {
            this.context = context;
        }

        public bool IsAuthorized(RoleCollection roles)
        {
            bool isAuthorized = this.context.IsUserInRole(roles);
            return isAuthorized;
        }
    }
}
