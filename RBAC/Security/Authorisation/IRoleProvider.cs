using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBAC.Security.Authorisation
{
    using RoleCollection = List<string>;
    /// <summary>
    /// Defines the contract for a role provider.
    /// </summary>
    public interface IRoleProvider
    {
        /// <summary>
        /// Gets the roles for a specific user.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>A collection of roles.</returns>
        RoleCollection? GetRolesForUser(string? username);
    }
}
