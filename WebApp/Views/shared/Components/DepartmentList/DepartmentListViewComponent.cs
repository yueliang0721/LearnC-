using Microsoft.AspNetCore.Mvc;
using WebApp.Model;

namespace WebApp.Views.shared.Components.DepartmentList
{
	[ViewComponent]
	public class DepartmentListViewComponent:ViewComponent
	{
		private IDepartmentRespository departmentRespository;
		public DepartmentListViewComponent(IDepartmentRespository departmentRespository)
		{
			this.departmentRespository = departmentRespository;
		}
		public IViewComponentResult Invoke(string? filter = null)
		{
			var departments = departmentRespository.GetDepartments(filter);
			return View(departments);
		}
	}
}
