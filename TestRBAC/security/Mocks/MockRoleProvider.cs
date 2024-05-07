namespace TestRBAC.security.Mocks
{
    using RBAC.Security.Authorisation;
    using RBAC.Security.Context;
    using RoleCollection = List<RBAC.Security.Authorisation.Role>;
    class MockRoleProvider : IRoleProvider
    {
        private MockUsers mockUsers = new MockUsers();

        public RoleCollection? GetRolesForUser(string? username)
        {
            Principal principal = mockUsers.GetUser(username);
            RoleCollection? roles = principal.Roles;
            return roles;
        }

    }
}


