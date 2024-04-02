namespace RBAC.Security.Context
{
    using RBAC.Security.Authentication;
    using RBAC.Security.Authorisation;

    using RoleCollection = List<String>;
    using Role = String;
    using System.Data;

    public class SecurityContext
    {

        private readonly IAuthenticator authenticator;
        private readonly IRoleProvider? roleProvider;

        public SecurityContext(IAuthenticator authenticator, IRoleProvider? roleProvider)
        {
            this.authenticator = authenticator;
            this.roleProvider = roleProvider;
        }

        public SecurityContext(IAuthenticator authenticator) : this(authenticator, null) { }
        
        private Principal? loggedInUser = null;
        public Principal? LoggedInUser
        {
            get
            {
                return loggedInUser;
            }
        }

        public Principal? Login(string username, string password)
        {
            Principal? currentUser = authenticator.Execute(username, password);
            if (currentUser is not null && roleProvider is not null)
            {
                RoleCollection? roles = roleProvider.GetRolesForUser(username);
                currentUser = new Principal(username, roles);
            }
            AuthorizeUser(currentUser);
            return loggedInUser;

        }

        private void AuthorizeUser(Principal? user)
        {
            loggedInUser = user;
        }

        public bool IsUserInRole(Role role)
        {
            return AuthorisationByRole.IsAuthorized(loggedInUser, role);
        }

        public bool IsUserInRole(RoleCollection roles)
        {
            return AuthorisationByRole.IsAuthorized(loggedInUser, roles);
        }
    }
}
