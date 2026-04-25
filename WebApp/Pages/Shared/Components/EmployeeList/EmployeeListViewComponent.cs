using Microsoft.AspNetCore.Mvc;
using WebApp.Model;

namespace WebApp.Pages.Shared.Components.EmployeeList
{
	[ViewComponent]
	public class EmployeeListViewComponent:ViewComponent
	{
		private IEmployeeRespository employeeRespository;
		public EmployeeListViewComponent(IEmployeeRespository employeeRespository)
		{
			this.employeeRespository = employeeRespository;
		}
		public IViewComponentResult Invoke(string? filter=null,int? departmentId = null)
		{
			var employees = employeeRespository.GetEmployees(filter, departmentId);
			return View(employees);
		}

	}
}
