using HobbyBackend.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCLient.Models;
using RBAC.Security.Context;

namespace RazorCLient.Pages
{
	public class HobbyModel : PageModel
	{
		private readonly SecurityContext context = Configuration.SecurityContextInstance;
		private readonly HobbyService _hobbyService = Configuration.CreateHobbyService();

		public List<HobbyDTO> Hobbies = [];

		[BindProperty]
		public HobbyDTO NewHobby { get; set; }

		[BindProperty]
		public PrincipalDTO LoginPrincipal { get; set; }

		[TempData]
		public string Message { get; set; } = "hallo";

		public HobbyModel()
		{
			LoginPrincipal = new() { Name = context?.LoggedInUser?.Name ?? "not logged in" };
			NewHobby = new();
		}

		public void OnGet()
		{
			Hobbies = _hobbyService.GetHobbies().Select(h => new HobbyDTO(h)).ToList();
		}

		public IActionResult OnPost()
		{
			try
			{
				_hobbyService.CreateHobby(NewHobby);
				Message = $"Hobby created {NewHobby}";
			}
			catch (Exception ex)
			{
				Message = ex.Message;
			}

			return RedirectToPage();
		}

		public IActionResult OnPostDelete()
		{
			try
			{
				_hobbyService.DeleteHobby(NewHobby);
				Message = $"Hobby deleted {NewHobby}";
			}
			catch (Exception ex)
			{
				Message = ex.Message;
			}

			return RedirectToPage();
		}
	}
}
