namespace RBAC.Security.Authorisation
{
    using Security.Context;
    using RoleCollection = List<Role>;
    /// <summary>
    /// Provides methods for authorizing a user based on their roles.
    /// </summary>
    public class AuthorisationByRole
    {
        /// <summary>
        /// Checks if the user is authorized for a specific role.
        /// </summary>
        /// <param name="principal">The user.</param>
        /// <param name="role">The role to check.</param>
        /// <returns>True if the user is authorized, false otherwise.</returns>
        public static bool IsAuthorized(Principal? principal, Role role)
        {
            if (principal is null)
            {
                return false;
            }
            else
            {
                return principal.Roles.Contains(role);
            }
        }

        /// <summary>
        /// Checks if the user is authorized for any of the specified roles.
        /// </summary>
        /// <param name="principal">The user.</param>
        /// <param name="roles">The roles to check.</param>
        /// <returns>True if the user is authorized for any role, false otherwise.</returns>
        public static bool IsAuthorized(Principal? principal, RoleCollection roles)
        {
            bool isAuthorized = false;
            foreach (Role role in roles)
            {
                if (IsAuthorized(principal, role))
                {
                    isAuthorized = true;
                }
            }
            return isAuthorized;
        }
    }
}
