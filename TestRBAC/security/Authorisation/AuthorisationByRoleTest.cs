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

            Assert.AreEqual(false, sc.isUserInRole(adminRole));
        }

        [TestMethod]
        public void WhenUserInRoleWithOneRoleShouldReturnTrue()
        {
            SecurityContext sc = new SecurityContext(new Principal("John", oneUserRoles));
            Assert.AreEqual(true, sc.isUserInRole(moderatorRole));

        }

        [TestMethod]
        public void WhenUserInRoleWithTwoRolesShouldReturnTrue()
        {
            SecurityContext sc = new SecurityContext(new Principal("John", twoUserRoles));
            
            Assert.AreEqual(true, sc.isUserInRole(moderatorRole));
            Assert.AreEqual(true, sc.isUserInRole(userRole));

        }

        [TestMethod]
        public void WhenUserInRoleWithTwoRolesWithoutAdminShouldReturnFalse()
        {
            SecurityContext sc = new SecurityContext(new Principal("John", twoUserRoles));

            Assert.AreEqual(false, sc.isUserInRole(adminRole));
        }


    }
}