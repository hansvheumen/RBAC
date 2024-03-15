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

        public bool isAuthorized(RoleCollection roles)
        {
            bool isAuthorized = false;
            foreach (var role in roles.Where(x => this.context.isUserInRole(x)))
            {
                isAuthorized = true;
                break;
            }
            return isAuthorized;
        }
    }
}
