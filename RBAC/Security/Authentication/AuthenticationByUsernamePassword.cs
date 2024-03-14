namespace RBAC.Security.Authentication
{
    using RBAC.Security.Context;
    using RoleCollection = List<String>;
    public class AuthenticationByUsernamePassword
    {
        private SecurityContext context;
        private Authenticator authenticator;
        private RoleProvider roleProvider;

        public AuthenticationByUsernamePassword(SecurityContext context, Authenticator authenticator, RoleProvider roleProvider)
        {
            this.context = context;
            this.authenticator = authenticator;
            this.roleProvider = roleProvider;
        }

        public bool Login(string username, string password)
        {
            Principal? currentUser = null;
            bool authenticated = authenticator.execute(username, password);
            if (authenticated)
            {
                RoleCollection? roles = roleProvider.getRolesForUser(username);
                currentUser = new Principal(username, roles);
            }
            AuthorizeUserToContext(currentUser);
            return currentUser != null;
        }


        protected void AuthorizeUserToContext(Principal? currentUser)
        {
            context.authorizeUser(currentUser);
        }

    }
}