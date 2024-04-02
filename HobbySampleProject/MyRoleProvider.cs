namespace Hobby
{
    using RBAC.Security.Authorisation;
    using RoleCollection = List<String>;
    internal class MyRoleProvider : IRoleProvider
    {
        public RoleCollection GetRolesForUser(string? username)
        {
            if (username == "Fisherman")
            {
                return ["Player"];
            }
            else
            {
                return ["Admin", "Moderator", "Player"];
            }
        }
    }
}
