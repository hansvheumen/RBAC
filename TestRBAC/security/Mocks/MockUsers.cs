namespace TestRBAC.security.Mocks
{
    using RBAC.Security.Authentication;
    using RBAC.Security.Context;
    using System.Collections.Specialized;
    using System.Security.Cryptography.X509Certificates;
    using RoleCollection = List<string>;
    class MockUsers
    {
        public enum Role
        {
            admin,
            user,
            moderator
        }

        public enum Username { 
            Adam,
            Ursula,
            Molly
        }


        Dictionary<string, Principal> users = new Dictionary<string, Principal>();

        public MockUsers()
        {
            string username = Username.Adam.ToString();
            users.Add(username, new Principal(username, new RoleCollection { Role.admin.ToString()}));
            username = Username.Ursula.ToString();
            users.Add(username, new Principal(username, new RoleCollection { Role.user.ToString() }));
            username = Username.Molly.ToString();
            users.Add(username, new Principal(username, new RoleCollection { Role.moderator.ToString(), Role.user.ToString() }));
        }

        public Principal GetUser(string username)
        {
            return users[username];
        }

    }

}



