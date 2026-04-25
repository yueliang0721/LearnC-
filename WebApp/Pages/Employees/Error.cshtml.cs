using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Employees
{
    public class ErrorModel : PageModel
    {
		public List<string?> Errors { get; set; }
		public void OnGet(List<string> errors)
        {
            Errors = errors ?? new List<string?>();
        }

		public void OnGetSecond(List<string> errors)
		{
			Errors = new List<string?>() { "Add","Delete"};
		}
	}
}
