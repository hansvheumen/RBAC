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

        public bool IsUserInRole(Role role)
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
                return loggedInUser.Roles.Contains(role);
            }

        }

        public bool IsUserInRole(RoleCollection roles)
        {
            bool isAuthorized = false;
            foreach (Role role in roles)
            {
                if (IsUserInRole(role))
                {
                    isAuthorized = true;
                }
            }
            return isAuthorized;
        }
    }
}
