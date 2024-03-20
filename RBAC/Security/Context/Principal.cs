namespace RBAC.Security.Context
{
    using RoleCollection = List<String>;

    public class Principal
    {
        public Principal(string name, RoleCollection roles)
        {
            Name = name;
            if (roles is null)
            {
                this.Roles = new RoleCollection();
            } else
            {
                this.Roles = roles;
            }            
        }

        public override string ToString()
        {
            return Name;
        }

        public string Name { get; }
        public RoleCollection Roles { get; }
    }
}
