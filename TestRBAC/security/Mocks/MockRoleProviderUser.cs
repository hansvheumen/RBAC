namespace TestRBAC.security.Mocks
{
    using RBAC.Security.Authorisation;

    class MockRoleProviderUser : IRoleProvider
    {
        private readonly MockUsers mockUsers = new();

        public RoleCollection GetRolesForUser(string username)
        {
            RoleCollection? roles = [MockUsers.roles["user"]];
            return roles;
        }

    }
}


