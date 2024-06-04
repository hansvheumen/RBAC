using HobbyRazorCLient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RBAC.Security.Context;

namespace HobbyRazorCLient.Pages
{
	public class LoginModel : PageModel
	{
		private readonly SecurityContext context;

		[BindProperty]
		public PrincipalDTO LoginPrincipal { get; set; }

		public LoginModel(SecurityContext context)
		{
			this.context = context;
			LoginPrincipal = new();
		}

		public void OnGet()
		{
			LoginPrincipal.Name = context?.LoggedInUser?.Name ?? "";
		}

		public IActionResult OnPost()
		{

			//context.Login("Fisherman", "shark");
			//context.Login("Admin", "Admin");
			context.Login(LoginPrincipal.Name, LoginPrincipal.Password);

			return RedirectToPage();
		}

		public IActionResult OnPostLogout()
		{
			context.Logout();

			return RedirectToPage();
		}

	}
}
