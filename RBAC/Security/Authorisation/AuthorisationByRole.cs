namespace RBAC.Security.Authorisation
{
    using RoleCollection = List<String>;
    public class AuthorisationByRole
    {
        private Security.Context.SecurityContext context;

        public AuthorisationByRole(Security.Context.SecurityContext context)
        {
            this.context = context;
        }

        public bool isAuthorized(RoleCollection roles)
        {
            bool isAuthorized = false;
            foreach (var role in roles)
            {
                if (this.context.isUserInRole(role))
                {
                    isAuthorized = true;
                    break;
                }
            }
            return isAuthorized;
        }
    }
}
