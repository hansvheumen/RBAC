namespace TestRBAC.security.Mocks
{
    using RBAC.Security.Authorisation;
    using RBAC.Security.Context;
    
    class MockRoleProvider : IRoleProvider
    {
        private readonly MockUsers mockUsers = new();

        public RoleCollection GetRolesForUser(string username)
        {
            Principal principal = mockUsers.GetUser(username);
            RoleCollection roles = principal.Roles;
            return roles;
        }

    }
}


