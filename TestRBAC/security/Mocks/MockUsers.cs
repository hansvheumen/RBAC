namespace TestRBAC.security.Mocks
{
    using RBAC.Security.Context;
    using RBAC.Security.Authorisation;
    using RoleCollection = List<RBAC.Security.Authorisation.Role>;
    class MockUsers
    {
        public enum Username
        {
            Adam,
            Ursula,
            Molly
        }

        Dictionary<string, Principal> users = new Dictionary<string, Principal>();

        public static Dictionary<string, Role> roles = new Dictionary<string, Role>()
        {
            { "admin", new Role("admin") },
            { "user", new Role("user") },
            { "moderator", new Role("moderator") }
        };

        public MockUsers()
        {
            string username = Username.Adam.ToString();
            users.Add(username, new Principal(username, new RoleCollection { roles["admin"] }));
            username = Username.Ursula.ToString();
            users.Add(username, new Principal(username, new RoleCollection { roles["user"] }));
            username = Username.Molly.ToString();
            users.Add(username, new Principal(username, new RoleCollection { roles["moderator"], roles["user"] }));
        }

        public Principal GetUser(string username)
        {
            return users[username];
        }

    }

}
