namespace TestRBAC.security.Mocks
{
    using RBAC.Security.Authentication;
    using RBAC.Security.Context;
    class MockAuthenticatorLargertThen3 : IAuthenticator
    {
        public Principal? Execute(string username, string password)
        {
            if (username.Length <= 3 || password.Length <= 3) return null;
            return new Principal(username);
        }
    }

}
