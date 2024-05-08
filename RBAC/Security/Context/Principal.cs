using RBAC.Security.Authorisation;

namespace RBAC.Security.Context
{

    /// <summary>
    /// Represents a principal user in the system.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Principal"/> class with roles.
    /// </remarks>
    /// <param name="name">The name of the user.</param>
    /// <param name="roles">The roles of the user.</param>
    public class Principal(string name, RoleCollection roles)
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Principal"/> class without roles.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        public Principal(string name) : this(name, [])
        {
        }

        /// <summary>
        /// Returns a string that represents the current user.
        /// </summary>
        /// <returns>A string that represents the current user.</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        public string Name { get; } = name;

        /// <summary>
        /// Gets the roles of the user.
        /// </summary>
        public RoleCollection Roles { get; } = roles ?? [];
    }
}
