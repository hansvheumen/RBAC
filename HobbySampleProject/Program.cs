namespace Hobby
{
    using RBAC.Security.Authorisation;
    using RBAC.Security.Context;
    using RBAC.Security.Authentication;
    public class Program
    {
        public static void Main(string[] args)
        {

            SecurityContext context = config();

            // Create a new HobbyService
            HobbyService hobbyService = new(context);


            //login as a Biker
            context.Login("Fisherman", "shark");
            hobbyService.createHobby("Fishing");
            hobbyService.deleteHobby("Fishing");

            //login as an Admin
            context.Login("Admin", "admin");
            hobbyService.createHobby("Debugging");
            hobbyService.deleteHobby("Debugging");
        }

        private static SecurityContext config()
        {
            IRoleProvider roleProvider = new MyRoleProvider();
            MyAuthenticator authenticator = new();
            SecurityContext context = new(authenticator, roleProvider);
            return context;
        }
    }
}
