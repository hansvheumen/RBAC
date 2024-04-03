namespace TestRBAC.security.Context
{
    using RBAC.Security.Authentication;
    using RBAC.Security.Authorisation;
    using RBAC.Security.Context;
    using TestRBAC.security.Mocks;

    using System.Net;
    using Role = String;
    using RoleCollection = List<String>;

    [TestClass]
    public class SecurityContextTest
    {
        static IAuthenticator authenticator = new MockAuthenticatorLargertThen3();
        static readonly IRoleProvider roleProvider = new MockRoleProvider();
        static SecurityContext sc = new SecurityContext(authenticator, roleProvider);

        [TestInitialize]
        public void TestInitialize()
        {
            authenticator = new MockAuthenticatorLargertThen3();
            sc = new SecurityContext(authenticator, roleProvider);
        }


        [TestMethod]
        public void Login_NotAuthenticatedUser_ReturnsNullCurrentUser()
        {
            authenticator = new MockAuthenticatorNotAuthenticated();
            sc = new SecurityContext(authenticator, roleProvider);

            Principal? admin = sc.Login(MockUsers.Username.Adam.ToString(), "admin");

            Assert.IsNull(admin);
            Assert.IsNull(sc.LoggedInUser);
        }

        [TestMethod]
        public void Login_AlwaysAuthenticatedUser_ReturnsNonNullCurrentUser()
        {
            authenticator = new MockAuthenticatorAlwaysAuthenticated();
            sc = new SecurityContext(authenticator, roleProvider);

            Principal? admin = sc.Login(MockUsers.Username.Adam.ToString(), "admin");

            Assert.IsNotNull(admin);
            Assert.IsNotNull(sc.LoggedInUser);
            Assert.AreEqual(admin, sc.LoggedInUser);

        }

        [TestMethod]
        public void Login_NullRoleProvider_ReturnsUserWithNoRoles()
        {
            authenticator = new MockAuthenticatorAlwaysAuthenticated();
            sc = new SecurityContext(authenticator, null);

            Principal? admin = sc.Login(MockUsers.Username.Adam.ToString(), "admin");

            Assert.AreEqual(0, admin.Roles.Count());

        }


        [TestMethod]
        public void Login_UserAuthorisedAndRoleProviderProvidesRoles_ReturnsUserWithRoles()
        {
            authenticator = new MockAuthenticatorAlwaysAuthenticated();
            IRoleProvider userRoleProvider = new MockRoleProviderUser();
            sc = new SecurityContext(authenticator, userRoleProvider);

            Principal? admin = sc.Login(MockUsers.Username.Adam.ToString(), "admin");

            Assert.AreEqual(1, admin.Roles.Count());
            Assert.AreEqual(MockUsers.Role.user.ToString(), admin.Roles.First());

        }
    }
}