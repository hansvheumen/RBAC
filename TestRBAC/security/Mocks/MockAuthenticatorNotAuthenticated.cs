namespace TestRBAC.security.Mocks
{
    using RBAC.Security.Authentication;
    using RBAC.Security.Context;
    using RoleCollection = List<string>;
    class MockAuthenticatorNotAuthenticated : IAuthenticator
    {
        public Principal? Execute(string username, string password)
        {
            return null;
        }
    }

}



