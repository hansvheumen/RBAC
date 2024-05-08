namespace TestRBAC.security.Mocks
{
    using RBAC.Security.Context;
    using RBAC.Security.Authorisation;
    using System.Collections.Generic;

    class MockUsers
    {
        public enum Username
        {
            Adam,
            Ursula,
            Molly
        }

        readonly Dictionary<string, Principal> users = [];

        public static Dictionary<string, Role> roles = new()
        {
            { "admin", new Role("admin") },
            { "user", new Role("user") },
            { "moderator", new Role("moderator") }
        };

        public MockUsers()
        {
            string username = Username.Adam.ToString();
            users.Add(username, new Principal(username, [ roles["admin"] ]));
            username = Username.Ursula.ToString();
            users.Add(username, new Principal(username, [ roles["user"] ]));
            username = Username.Molly.ToString();
            users.Add(username, new Principal(username, [ roles["moderator"], roles["user"] ]));

        }

        public Principal GetUser(string username)
        {
            return users[username];
        }

    }

}
