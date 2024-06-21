using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorClient.Pages
{
	public class IndexModel : PageModel
	{

		public IndexModel()
		{

		}

		public IActionResult OnGet()
		{
			return RedirectToPage("/Login");
		}
	}
}
