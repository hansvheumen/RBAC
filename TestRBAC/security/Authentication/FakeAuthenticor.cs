namespace TestRBAC.security.Authentication
{
    using RBAC.Security.Authentication;
    using RoleCollection = List<String>;
    class FakeAuthenticor : Authenticator
    {
        public bool execute(string username, string password)
        {
            if (username.Length >3 && password.Length>3)
            {
                return true;
            }           
            else
            {
                return false;
            }
        }
    }

}
}


