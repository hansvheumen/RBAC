namespace Hobby
{
    using RBAC.Security.Authorisation;
    using RBAC.Security.Context;
    using RBAC.Security.Authentication;
    public class Program
    {
        public static void Main(string[] args)
        {

            SecurityContext context = Config();

            // Create a new HobbyService
            HobbyService hobbyService = new(context);


            //login as a Biker
            context.Login("Fisherman", "shark");
            hobbyService.CreateHobby("Fishing");
            hobbyService.DeleteHobby("Fishing");

            //login as an Admin
            context.Login("Admin", "admin");
            hobbyService.CreateHobby("Debugging");
            hobbyService.DeleteHobby("Debugging");
        }

        private static SecurityContext Config()
        {
            IRoleProvider roleProvider = new MyRoleProvider();
            IAuthenticator authenticator = new MyAuthenticator();
            SecurityContext context = new(authenticator, roleProvider);
            return context;
        }
    }
}
