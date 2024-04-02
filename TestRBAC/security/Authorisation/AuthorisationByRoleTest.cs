namespace TestRBAC.security.Authorisation
{

    using RBAC.Security.Context;
    using RBAC.Security.Authentication;
    using TestRBAC.security.Mocks;
    using Role = String;
    using RoleCollection = List<String>;
    using RBAC.Security.Authorisation;

    [TestClass]
    public class AuthorisationByRoleTest
    {

        static readonly Role adminRole = MockUsers.Role.admin.ToString();
        static readonly Role moderatorRole = MockUsers.Role.moderator.ToString();
        static readonly Role userRole = MockUsers.Role.user.ToString();

        readonly RoleCollection appRoles = [adminRole, moderatorRole, userRole];
        readonly RoleCollection oneUserRoles = [userRole];
        readonly RoleCollection oneModeratorRoles = [moderatorRole];
        readonly RoleCollection userModeratorRoles = [moderatorRole, userRole];

        static readonly IAuthenticator authenticator = new MockAuthenticatorLargertThen3();
        static readonly IRoleProvider roleProvider = new MockRoleProvider();
        static SecurityContext sc = new SecurityContext(authenticator, roleProvider);

        //[ClassInitialize]
        //public static void ClassInitialize()
        //{
        //     sc = new SecurityContext(authenticator, roleProvider);
        //}

        [TestMethod]
        public void IsAuthorizedWhenUserIsNullThenReturnFalse()
        {
            Assert.IsFalse(AuthorisationByRole.IsAuthorized(null, adminRole));
        }


        [TestMethod]
        public void IsAuthorizedWhenUserHasNoRolesThenReturnFalse()
        {
            Principal? user = new Principal("user", null);
            Assert.IsFalse(AuthorisationByRole.IsAuthorized(user, adminRole));
            Assert.IsFalse(AuthorisationByRole.IsAuthorized(user, userModeratorRoles));
        }

        [TestMethod]
        public void IsAuthorizedWhenUserHasUserRole()
        {
            Principal? user = new Principal("user", oneUserRoles);
            Assert.IsFalse(AuthorisationByRole.IsAuthorized(user, adminRole));
            Assert.IsTrue(AuthorisationByRole.IsAuthorized(user, userModeratorRoles));
            Assert.IsTrue(AuthorisationByRole.IsAuthorized(user, userRole));
        }

        [TestMethod]
        public void IsAuthorizedWhenUserHasUserAndModeratorRole()
        {
            Principal? user = new Principal("user", userModeratorRoles);
            Assert.IsFalse(AuthorisationByRole.IsAuthorized(user, adminRole));
            Assert.IsTrue(AuthorisationByRole.IsAuthorized(user, userModeratorRoles));
            Assert.IsTrue(AuthorisationByRole.IsAuthorized(user, userRole));
        }

    }
}