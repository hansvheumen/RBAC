namespace RBAC.Security.Context
{
    using RBAC.Security.Authentication;
    using RBAC.Security.Authorisation;

    using RoleCollection = List<RBAC.Security.Authorisation.Role>;

    /// <summary>
    /// Represents the security context of the application.
    /// </summary>
    public class SecurityContext
    {
        private readonly IAuthenticator authenticator;
        private readonly IRoleProvider? roleProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityContext"/> class.
        /// </summary>
        /// <param name="authenticator">The authenticator.</param>
        /// <param name="roleProvider">The role provider.</param>
        public SecurityContext(IAuthenticator authenticator, IRoleProvider? roleProvider)
        {
            this.authenticator = authenticator;
            this.roleProvider = roleProvider;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityContext"/> class.
        /// </summary>
        /// <param name="authenticator">The authenticator.</param>
        public SecurityContext(IAuthenticator authenticator) : this(authenticator, null) { }

        private Principal? loggedInUser = null;

        /// <summary>
        /// Gets the logged in user.
        /// </summary>
        public Principal? LoggedInUser
        {
            get
            {
                return loggedInUser;
            }
        }

        /// <summary>
        /// Logs in the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>The logged in user.</returns>
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

        /// <summary>
        /// Authorizes the user.
        /// </summary>
        /// <param name="user">The user.</param>
        private void AuthorizeUser(Principal? user)
        {
            loggedInUser = user;
        }

        /// <summary>
        /// Checks if the user is in the specified role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>True if the user is in the role, false otherwise.</returns>
        public bool IsUserInRole(Role role)
        {
            return AuthorisationByRole.IsAuthorized(loggedInUser, role);
        }

        /// <summary>
        /// Checks if the user is in any of the specified roles.
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <returns>True if the user is in any of the roles, false otherwise.</returns>
        public bool IsUserInRole(RoleCollection roles)
        {
            return AuthorisationByRole.IsAuthorized(loggedInUser, roles);
        }
    }
}