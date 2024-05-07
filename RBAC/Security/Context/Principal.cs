using RBAC.Security.Authorisation;

namespace RBAC.Security.Context
{
    using RoleCollection = List<Role>;

    /// <summary>
    /// Represents a principal user in the system.
    /// </summary>
    public class Principal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Principal"/> class.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        /// <param name="roles">The roles of the user.</param>
        public Principal(string name, RoleCollection? roles)
        {
            Name = name;
            if (roles is null)
            {
                this.Roles = new RoleCollection();
            }
            else
            {
                this.Roles = roles;
            }
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
        public string Name { get; }

        /// <summary>
        /// Gets the roles of the user.
        /// </summary>
        public RoleCollection Roles { get; }
    }
}
