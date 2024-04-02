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
    public class SecurityContextIT
    {

        static readonly Role adminRole = MockUsers.Role.admin.ToString();
        static readonly Role moderatorRole = MockUsers.Role.moderator.ToString();
        static readonly Role userRole = MockUsers.Role.user.ToString();

        static readonly RoleCollection appRoles = [adminRole, moderatorRole, userRole];

        static readonly RoleCollection methodModeratorRole = [moderatorRole];
        static readonly RoleCollection methodUserAndAdminRole = [userRole, adminRole];


        static readonly RoleCollection userModeratorRoles = [moderatorRole];
        static readonly RoleCollection userModeratorAndUserRole = [moderatorRole, userRole];

        static readonly IAuthenticator authenticator = new MockAuthenticatorLargertThen3();
        static readonly IRoleProvider roleProvider = new MockRoleProvider();
        static SecurityContext sc = new SecurityContext(authenticator, roleProvider);

        [TestInitialize]
        public void TestInitialize()
        {
            sc = new SecurityContext(authenticator, roleProvider);
        }

        [TestMethod]
        public void whenUserIsModeratorAndMethodIsAuthorisedForModerator()
        {
         
            Principal? admin = sc.Login(MockUsers.Username.Adam.ToString(), "admin");

            Assert.IsNotNull(admin);
            Assert.IsTrue(sc.IsUserInRole(methodUserAndAdminRole));
            Assert.IsFalse(sc.IsUserInRole(methodModeratorRole));
            Assert.IsTrue(sc.IsUserInRole(methodUserAndAdminRole));

        }

        [TestMethod]
        public void whenAndMethodHasTwoAuthisationsAndUserHasTwoAutorisationsShouldReturnTrue()
        {
            Principal? moderator = sc.Login(MockUsers.Username.Molly.ToString(), "moderator");

            Assert.IsTrue(sc.IsUserInRole(methodUserAndAdminRole));

        }


    }
}