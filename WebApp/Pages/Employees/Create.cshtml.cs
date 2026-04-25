using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Helpers;
using WebApp.Model;
using WebApp.ViewModels;
namespace WebApp.Pages.Employees
{
    [BindProperties]//这个类里面的所有属性 全部绑定
    public class CreateModel : PageModel
    {
        private IDepartmentRespository departmentRespository;
        private IEmployeeRespository employeeRespository;
		public CreateModel(IDepartmentRespository departmentRespository,IEmployeeRespository employeeRespository)
		{
			this.departmentRespository = departmentRespository;
            this.employeeRespository = employeeRespository;
		}

		[BindProperty]
		public EmployeeViewModel? EmployeeViewModel { get; set; }
		public void OnGet()
        {
            EmployeeViewModel = new();
            EmployeeViewModel.Employee = new();
            EmployeeViewModel.departments = departmentRespository.GetDepartments();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                var errors = ModelStateHelper.GetErrors(ModelState);
                return RedirectToPage("Error", new {errors=errors});
            }

            if(EmployeeViewModel == null)
            {
				var errors = ModelStateHelper.GetErrors(ModelState);
				return RedirectToPage("Error", new { errors = errors });//这里使用动态对象 是因为在Error的页面中，没有接受errors的路由参数，使用动态对象就相当于使用了Query参数 直接强制绑定到页面控制器上
			}
            employeeRespository.AddEmployee(EmployeeViewModel.Employee);
            return RedirectToPage("/Employees/index");
        }
    }
}
