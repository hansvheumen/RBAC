using HobbyProject.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HobbyRazorCLient.Models;

namespace HobbyRazorCLient.Pages
{
	public class HobbyModel : PageModel
	{
		private readonly HobbyService _hobbyService;

		public List<HobbyDTO> Hobbies = [];

		[BindProperty]
		public HobbyDTO NewHobby { get; set; }

		[TempData]
		public string Message { get; set; } = "hallo";

		public HobbyModel(HobbyService hobbyService)
		{
			_hobbyService = hobbyService;
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
