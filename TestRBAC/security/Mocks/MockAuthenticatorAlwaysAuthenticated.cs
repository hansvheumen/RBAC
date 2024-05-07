namespace TestRBAC.security.Mocks
{
    using RBAC.Security.Authentication;
    using RBAC.Security.Context;
    class MockAuthenticatorAlwaysAuthenticated : IAuthenticator
    {
        public Principal? Execute(string username, string password)
        {
            return new Principal(username, null);
        }
    }

}
