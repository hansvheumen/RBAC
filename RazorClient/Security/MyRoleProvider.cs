namespace RazorCLient.Security
{
    using RBAC.Security.Authorisation;


    internal class MyRoleProvider : IRoleProvider
    {
        private readonly Dictionary<string, RoleCollection> _roles = new()
        {
            {  "Fisherman", [new("Player")] },
            {  "Admin", [new("Admin"), new("Moderator")]},
        };

        public RoleCollection GetRolesForUser(string username)
        {
            return _roles[username] ?? [];
        }
    }
}
