using RBAC.Security.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRBAC.security.Authentication
{
    [TestClass]
     class AuthenticationTest
    {


        [TestMethod]
        public void WhenEmptyUserInRoleShouldReturnFalse()
        {
            SecurityContext sc = new SecurityContext();

            Assert.IsFalse(sc.IsUserInRole("adminRole"));
        }
    }
}
