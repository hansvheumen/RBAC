namespace Hobby
{
    using RBAC.Security.Authorisation;
    using RoleCollection = List<RBAC.Security.Authorisation.Role>;
    internal class MyRoleProvider : IRoleProvider
    {
        public RoleCollection GetRolesForUser(string? username)
        {
            if (username == "Fisherman")
            {
                return [new("Player")];
            }
            else
            {
                return [new("Admin"), new("Moderator"), new("Player")];
            }
        }
    }
}
