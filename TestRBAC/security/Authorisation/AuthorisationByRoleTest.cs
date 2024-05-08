namespace TestRBAC.security.Authorisation
{

    using RBAC.Security.Context;
    using RBAC.Security.Authorisation;
    using TestRBAC.security.Mocks;

    [TestClass]
    public class AuthorisationByRoleTest
    {
        static readonly Role adminRole = MockUsers.roles["admin"];
        static readonly Role moderatorRole = MockUsers.roles["moderator"];
        static readonly Role userRole = MockUsers.roles["user"];

        readonly RoleCollection appRoles = [adminRole, moderatorRole, userRole];
        readonly RoleCollection oneUserRoles = [userRole];
        readonly RoleCollection oneModeratorRoles = [moderatorRole];
        readonly RoleCollection userModeratorRoles = [moderatorRole, userRole];


        [TestMethod]
        public void IsAuthorized_UserIsNull_ReturnsFalse()
        {
            Assert.IsFalse(AuthorisationByRole.IsAuthorized(null, adminRole));
        }

        [TestMethod]
        public void IsAuthorized_UserHasNoRoles_ReturnsFalse()
        {
            Principal? user = new("user");
            Assert.IsFalse(AuthorisationByRole.IsAuthorized(user, adminRole));
            Assert.IsFalse(AuthorisationByRole.IsAuthorized(user, userModeratorRoles));
        }

        [TestMethod]
        public void IsAuthorized_UserHasUserRole_ReturnsExpectedAuthorization()
        {
            Principal? user = new("user", oneUserRoles);
            Assert.IsFalse(AuthorisationByRole.IsAuthorized(user, adminRole));
            Assert.IsTrue(AuthorisationByRole.IsAuthorized(user, userModeratorRoles));
            Assert.IsTrue(AuthorisationByRole.IsAuthorized(user, userRole));
        }

        [TestMethod]
        public void IsAuthorized_UserHasUserAndModeratorRole_ReturnsExpectedAuthorization()
        {
            Principal? user = new("user", userModeratorRoles);
            Assert.IsFalse(AuthorisationByRole.IsAuthorized(user, adminRole));
            Assert.IsTrue(AuthorisationByRole.IsAuthorized(user, userModeratorRoles));
            Assert.IsTrue(AuthorisationByRole.IsAuthorized(user, userRole));
        }
    }
}