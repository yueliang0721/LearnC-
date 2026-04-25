using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Helpers;
using WebApp.Model;
using WebApp.ViewModels;

namespace WebApp.Pages.Employees
{
    public class EditModel : PageModel
    {
		private IDepartmentRespository departmentRespository;
		private IEmployeeRespository employeeRespository;
		public EditModel(IDepartmentRespository departmentRespository, IEmployeeRespository employeeRespository)
		{
			this.departmentRespository = departmentRespository;
			this.employeeRespository = employeeRespository;
		}
		[BindProperty]//这里从post绑定
		public EmployeeViewModel? ViewModel { get; set; }

		public int EmployeeId { get; set; }

		public IActionResult OnGet(int EmployeeId)//直接绑定到属性
        {
			if(!ModelState .IsValid)
			{
				var errors = ModelStateHelper.GetErrors(ModelState);
				return RedirectToPage("Error", new {errors});
			}
			ViewModel = new();
			ViewModel.Employee = employeeRespository.GetEmployeeById(EmployeeId);
			ViewModel.departments = departmentRespository.GetDepartments();
			this.EmployeeId = EmployeeId;
			return Page();
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return RedirectToPage("Error",new { errors = ModelStateHelper.GetErrors(ModelState) });
			}
			if(ViewModel is not null)
			{
				(var employee, _) = ViewModel;//结构函数
				employeeRespository.UpdateEmployee(employee);
			}
			return RedirectToPage("Index");

		}

		public IActionResult OnPostDeleteEmployee(int EmployeeId)
		{
			if(!ModelState.IsValid)
			{
				return RedirectToPage("Error", new { errors = ModelStateHelper.GetErrors(ModelState) });
			}

			var employee = employeeRespository.GetEmployeeById(EmployeeId);
			if (employee != null)
			{
				employeeRespository.DeleteEmployee(employee);
			}
			return RedirectToPage("Index");
		}
    }
}
