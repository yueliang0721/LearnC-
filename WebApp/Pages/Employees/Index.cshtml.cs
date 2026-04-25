using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Filters;
using WebApp.Model;

namespace WebApp.Pages.Employees
{
    //[TypeFilter(typeof(WriteToConsoleResourceFilter))]
    public class IndexModel : PageModel
    {
		public void OnGet()
        {
            //Employees = EmployeeRespository.GetEmployees();
        }

        public IActionResult OnGetSearchEmployees(string? filter)
        {
            return ViewComponent("EmployeeList", new {filter=filter});
        }
    }
}
