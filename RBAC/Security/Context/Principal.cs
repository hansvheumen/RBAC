using RBAC.Security.Authorisation;

namespace RBAC.Security.Context
{

    public class Principal(string name, RoleCollection roles)
    {

        public Principal(string name) : this(name, [])
        {
        }

        public override string ToString()
        {
            return Name;
        }

        public string Name { get; } = name;

        public RoleCollection Roles { get; } = roles ?? [];
    }
}
