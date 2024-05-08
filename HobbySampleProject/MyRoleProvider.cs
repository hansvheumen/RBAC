namespace Hobby
{
    using RBAC.Security.Authorisation;

    internal class MyRoleProvider : IRoleProvider
    {
        public RoleCollection GetRolesForUser(string username)
        {
            RoleCollection roles;
            if (username == "Fisherman")
            {
                roles = [new("Player")];
            }
            else
            {
                roles = [new("Admin"), new("Moderator"), new("Player")];
            }
            return roles;
        }
    }
}
