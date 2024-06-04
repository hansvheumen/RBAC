namespace Hobby
{
	using HobbyProject.services;
	using RBAC.Security.Authentication;
	using RBAC.Security.Authorisation;
	using RBAC.Security.Context;
	using System.Diagnostics;

	public class Program
	{
		public static void Main(string[] args)
		{

			SecurityContext context = Config();

			// Create a new HobbyService
			HobbyService hobbyService = new(context);


			//login as a Fisherman
			context.Login("Fisherman", "shark");
			Hobby fishing = new Hobby("Fishing", "");
			try
			{
				hobbyService.CreateHobby(fishing);
				Debug.WriteLine($"Hobby created {fishing}");
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			try
			{
				hobbyService.DeleteHobby(fishing);
			}
			catch (Exception ex)
			{

				Debug.WriteLine(ex.Message);
			}


			//login as an Admin
			context.Login("Admin", "admin");
			Hobby debugging = new Hobby("Debugging", "");
			try
			{
				hobbyService.CreateHobby(debugging);
				Debug.WriteLine($"Hobby created {debugging}");
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			try
			{
				hobbyService.DeleteHobby(debugging);
				Debug.WriteLine($"Hobby deleted {debugging}");
			}
			catch (Exception ex)
			{

				Debug.WriteLine(ex.Message);
			}
		
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
