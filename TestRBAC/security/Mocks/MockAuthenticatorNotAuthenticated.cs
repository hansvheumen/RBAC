namespace TestRBAC.security.Mocks
{
    using RBAC.Security.Authentication;
    using RBAC.Security.Context;
    class MockAuthenticatorNotAuthenticated : IAuthenticator
    {
        public Principal? Execute(string username, string password)
        {
            return null;
        }
    }

}
