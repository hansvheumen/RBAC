using HobbyBackend.DAL;
using HobbyBackend.services;
using RazorCLient.Security;
using RBAC.Security.Context;

namespace RazorCLient
{
	public class Configuration
	{
		private static SecurityContext securityContext = null;
		private static IHobbyDAO hobbyDAO = null;


		// Private constructor to prevent instantiation
		private Configuration() { }

		public static SecurityContext SecurityContextInstance
		{
			get
			{
				if (securityContext != null) return securityContext;

				securityContext = new SecurityContext(new MyAuthenticator(), new MyRoleProvider());
				return securityContext;
			}
		}
		private static IHobbyDAO HobbyDAO
		{
			get
			{
				if (hobbyDAO != null) return hobbyDAO;

				hobbyDAO = new HobbyDAO();
				return hobbyDAO;
			}
		}

		public static HobbyService CreateHobbyService()
		{
			return new HobbyService(HobbyDAO, SecurityContextInstance);
		}

	}
}
