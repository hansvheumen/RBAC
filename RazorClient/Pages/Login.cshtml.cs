using RazorCLient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RBAC.Security.Context;

namespace RazorCLient.Pages
{
	public class LoginModel : PageModel
	{
		private readonly SecurityContext context = Configuration.SecurityContextInstance;

		[BindProperty]
		public PrincipalDTO LoginPrincipal { get; set; }

		public LoginModel()
		{
			LoginPrincipal = new();
		}

		public void OnGet()
		{
			LoginPrincipal.Name = context?.LoggedInUser?.Name ?? "";
		}

		public IActionResult OnPost()
		{
			context.Login(LoginPrincipal.Name, LoginPrincipal.Password);

			return RedirectToPage("/Hobby");
		}

		public IActionResult OnPostLogout()
		{
			context.Logout();

			return RedirectToPage();
		}

	}
}
