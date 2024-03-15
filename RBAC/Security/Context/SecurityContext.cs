namespace RBAC.Security.Context
{
    using RoleCollection = List<String>;
    using Role = String;

    public class SecurityContext
    {
        private Principal? loggedInUser = null;
        public Principal? LoggedInUser
        {
            get
            {
                return loggedInUser;
            }
        }

        public SecurityContext(Principal? user)
        {
            loggedInUser = user;
        }

        public SecurityContext() : this(null)
        {
        }

        public void authorizeUser(Principal? user)
        {
            loggedInUser = user;
        }

        public bool isUserInRole(Role? role)
        {
            if (loggedInUser is null)
            {
                return false;
            }
            else if (role is null)
            {
                return false;
            }
            else
            {
                return loggedInUser.roles.Contains(role);
            }

        }
    }
}
