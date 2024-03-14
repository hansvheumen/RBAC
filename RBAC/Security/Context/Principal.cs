namespace RBAC.Security.Context
{
    using RoleCollection = List<String>;

    public class Principal
    {
        public Principal(string? name, RoleCollection? roles)
        {
            Name = name;
            this.roles = roles;
        }
        public string? Name { get; }
        public RoleCollection? roles { get; }
    }
}
