namespace TestRBAC.security.Mocks
{
    using RBAC.Security.Authentication;
    using RBAC.Security.Context;
    using RoleCollection = List<string>;
    class MockAuthenticatorLargertThen3 : IAuthenticator
    {
        public Principal? Execute(string username, string password)
        {
            if (username.Length > 3 && password.Length > 3)
            {
                return new Principal(username, null);
            }
            else
            {
                return null;
            }
        }
    }

}



