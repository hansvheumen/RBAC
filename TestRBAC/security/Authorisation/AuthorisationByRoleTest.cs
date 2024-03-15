namespace TestRBAC.security.Authorisation
{

    using RBAC.Security.Context;
    using Role = String;
    using RoleCollection = List<String>;

    [TestClass]
    public class AuthorisationByRoleTest
    {

        static Role adminRole = "Admin";
        static Role moderatorRole = "Moderator";
        static Role userRole = "User";

        RoleCollection appRoles = [adminRole, moderatorRole, userRole];

        RoleCollection oneUserRoles = [moderatorRole];
        RoleCollection twoUserRoles = [moderatorRole, userRole];



        [TestMethod]
        public void WhenEmptyUserInRoleShouldReturnFalse()
        {
            SecurityContext sc = new SecurityContext();

            Assert.IsFalse(sc.IsUserInRole(adminRole));
        }

        [TestMethod]
        public void WhenUserInRoleWithOneRoleShouldReturnTrue()
        {
            SecurityContext sc = new SecurityContext(new Principal("John", oneUserRoles));
            Assert.IsTrue(sc.IsUserInRole(moderatorRole));

        }

        [TestMethod]
        public void WhenUserInRoleWithTwoRolesShouldReturnTrue()
        {
            SecurityContext sc = new SecurityContext(new Principal("John", twoUserRoles));

            Assert.IsTrue(sc.IsUserInRole(moderatorRole));
            Assert.IsTrue(sc.IsUserInRole(userRole));

        }

        [TestMethod]
        public void WhenUserInRoleWithTwoRolesWithoutAdminShouldReturnFalse()
        {
            SecurityContext sc = new SecurityContext(new Principal("John", twoUserRoles));

            Assert.IsFalse(sc.IsUserInRole(adminRole));
        }


    }
}