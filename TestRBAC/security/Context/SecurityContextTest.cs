namespace TestRBAC.security.Context
{
    using RBAC.Security.Authorisation;
    using RBAC.Security.Context;
    using Role = String;
    using RoleCollection = List<String>;

    [TestClass]
    public class SecurityContextTest
    {

        static Role adminRole = "Admin";
        static Role moderatorRole = "Moderator";
        static Role userRole = "User";

        static RoleCollection appRoles = [adminRole, moderatorRole, userRole];

        static RoleCollection methodModeratorRole = [moderatorRole];
        static RoleCollection methodUserAndAdminRole = [userRole, adminRole];


        static RoleCollection userModeratorRoles = [moderatorRole];
        static RoleCollection userModeratorAndUserRole = [moderatorRole, userRole];


        SecurityContext? sc;
        AuthorisationByRole? abr;


        [TestMethod]
        public void whenUserIsModeratorAndMethodIsAuthorisedForModerator()
        {
            sc = new SecurityContext((new Principal("John", userModeratorRoles)));
            abr = new AuthorisationByRole(sc);

            Assert.IsTrue(abr.isAuthorized(methodModeratorRole));
            Assert.IsFalse(abr.isAuthorized(methodUserAndAdminRole));

        }

        [TestMethod]
        public void whenAndMethodHasTwoAuthisationsAndUserHasTwoAutorisationsShouldReturnTrue()
        {
            sc = new SecurityContext((new Principal("John", userModeratorAndUserRole)));
            abr = new AuthorisationByRole(sc);

            Assert.IsTrue(abr.isAuthorized(methodUserAndAdminRole));

        }
        [TestMethod]
        public void whenAndMethodHasOneAuthisationsAndUserHasTwoAutorisationsShouldReturnFalse()
        {
            sc = new SecurityContext((new Principal("John", userModeratorRoles)));
            abr = new AuthorisationByRole(sc);

            Assert.IsFalse(abr.isAuthorized(methodUserAndAdminRole));

        }



    }
}