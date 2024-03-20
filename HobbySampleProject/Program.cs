namespace Hobby
{
    using RBAC.Security.Authorisation;
    using RBAC.Security.Context;
    using RBAC.Security.Authentication;
    public class Program
    {
        public static void Main(string[] args)
        {
            // Configure the security context
            SecurityContext context = new SecurityContext();
            AuthorisationByRole auth = new AuthorisationByRole(context);
            MyRoleProvider roleProvider = new MyRoleProvider();
            MyAuthenticator authenticator = new MyAuthenticator();
            AuthenticationByUsernamePassword authentication = new AuthenticationByUsernamePassword(context, authenticator, roleProvider);
            // end of configuration



            // Create a new HobbyService
            HobbyService hobbyService = new HobbyService(context);
            

            //login as a Biker
            authentication.Login("Biker", "wheel");        
            hobbyService.createHobby("Fishing");
            hobbyService.deleteHobby("Fishing");

            //login as a Admin
            authentication.Login("Admin", "admin");
            hobbyService.createHobby("Fishing");
            hobbyService.deleteHobby("Fishing");
        }
    
    }
}
