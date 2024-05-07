namespace TestRBAC.security.Context
{
    using RBAC.Security.Authentication;
    using RBAC.Security.Authorisation;
    using RBAC.Security.Context;
    using TestRBAC.security.Mocks;

    using System.Net;
    using RoleCollection = List<RBAC.Security.Authorisation.Role>;

    [TestClass]
    public class SecurityContextIT
    {
        static readonly Role adminRole = MockUsers.roles["admin"];
        static readonly Role moderatorRole = MockUsers.roles["moderator"];
        static readonly Role userRole = MockUsers.roles["user"];

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
        public void IsUserInRole_UserIsAdminAndMethodIsAuthorisedForAdmin_ReturnsExpectedAuthorization()
        {
         
            Principal? admin = sc.Login(MockUsers.Username.Adam.ToString(), "admin");

            Assert.IsNotNull(admin);
            Assert.IsTrue(sc.IsUserInRole(methodUserAndAdminRole));
            Assert.IsFalse(sc.IsUserInRole(methodModeratorRole));
            Assert.IsFalse(sc.IsUserInRole(userModeratorAndUserRole));

        }

        [TestMethod]
        public void IsUserInRole_MethodAndUserHaveTwoAuthorizations_ReturnsTrue()
        {
            Principal? moderator = sc.Login(MockUsers.Username.Molly.ToString(), "moderator");

            Assert.IsTrue(sc.IsUserInRole(methodUserAndAdminRole));

        }


    }
}