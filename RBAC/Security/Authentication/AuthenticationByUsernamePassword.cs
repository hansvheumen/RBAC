namespace RBAC.Security.Authentication
{
    using RBAC.Security.Context;
    using RoleCollection = List<String>;
    public class AuthenticationByUsernamePassword
    {
        private readonly SecurityContext context;
        private readonly IAuthenticator authenticator;
        private readonly IRoleProvider roleProvider;

        public AuthenticationByUsernamePassword(SecurityContext context, IAuthenticator authenticator, IRoleProvider roleProvider)
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