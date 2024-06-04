namespace Hobby
{
    using RBAC.Security.Authorisation;
    using System.Linq.Expressions;

    internal class MyRoleProvider : IRoleProvider
    {
        private Dictionary<string, RoleCollection> _roles = new()
        {
            {  "Fisherman", [new("Player")] },
            {  "Admin", [new("Admin"), new("Moderator"), new("Player")]},
        };

        public RoleCollection GetRolesForUser(string username)
        {
            return _roles[username] ?? [];
        }
    }
}
