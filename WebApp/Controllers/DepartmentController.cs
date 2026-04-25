using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using WebApp.Filters;
using WebApp.Helpers;
using WebApp.Model;

namespace WebApp.Controllers
{
	//[WriteToConsoleResourceFilter(Description = "DepartmentController",Order =-1)]
	public class DepartmentController : Controller
	{
		private IDepartmentRespository departmentRespository;
		public DepartmentController(IDepartmentRespository departmentRespository)
		{
			this.departmentRespository = departmentRespository;
		}

		//[TypeFilter(typeof(WriteToConsoleResourceFilter))]
		//[WriteToConsoleResourceFilter(Description = "Department Index Method",Order = -2)]
		[DateExpiredFilter(ExpiredTime = "26-5-30")]
		public IActionResult Index()
		{
			var departments = departmentRespository.GetDepartments();
			return View(departments);
		}

		public IActionResult Create()
		{

			return View();
		}

		[EnsureModelValidateFilter]
		public IActionResult AddDepartment([FromForm] Department? department)
		{

			////前端提交数据 框架会自动new一个Department出来 绝对不会为空
			//if(!ModelState.IsValid)
			//{
			//	var errors = ModelStateHelper.GetErrors(ModelState);
			//	return View("Error", errors);
			//}

			//if (department == null)
			//{

			//	return View("Error");
			//}

			departmentRespository.AddDepartment(department);
			Console.WriteLine(department!.Id);
			return RedirectToAction("Index");
			
		}

		[EnsureModelActionFilter]//这里进行模型绑定验证确保模型不为空
		public IActionResult Edit([FromRoute] int? id)
		{
			//if (id == null)
			//{
			//	View("Error");
			//}
			var department = departmentRespository.GetDepartments().FirstOrDefault(x => x.Id == id);
			return View(department);
		}

		[EnsureModelValidateFilter]
		public IActionResult UpdateDepartment([FromForm] Department? department)
		{
			//if (department == null)
			//{
			//	Console.WriteLine("更新表单是空的");
			//	return RedirectToAction("Index");
			//}
			Console.WriteLine(department.Name);
			departmentRespository.UpdateDepartment(department);
			return RedirectToAction("Index");
		}

		[EnsureModelActionFilter] //确保id合法 并且仓库里有
		public IActionResult Delete([FromRoute] int? id)
		{
			//if (id == null)
			//{
			//	return View("Error");
			//}
			//var department = departmentRespository.GetDepartments().FirstOrDefault(x => x.Id == id);
			//if (department != null)
			//{
			//	
			//}
			departmentRespository.DeleteDepartmentById(id);
			return RedirectToAction("Index");
		}

		public IActionResult SearchDepartment([FromQuery]string? filter = null)
		{

			return ViewComponent("DepartmentList", new { filter });

		}

		//[TypeFilter(typeof(WriteToConsoleResourceFilter))]
		[EnsureModelActionFilter]
		public IActionResult Detail([FromRoute]int? id)//这里必须是id 因为参数模板规定了
		{
			var department = departmentRespository.GetDepartmentById(id);
			return View(department);
		}

		[HttpGet]
		[WebApiEndpointFilter]
		public IActionResult GetDepartment()
		{
			throw new Exception("Cuowu");
			return Json(departmentRespository.GetDepartments());
		}
	}
}
