using Microsoft.AspNetCore.Mvc;
using WebApp.Model;
namespace WebApp.Views.shared.Components.DepartmentItem
{
	[ViewComponent]
	public class DepartmentItemViewComponent:ViewComponent
	{
		public IViewComponentResult Invoke(Department department)
		{
			return View(department);
		}
	}
}
