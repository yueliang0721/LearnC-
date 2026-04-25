using Microsoft.AspNetCore.Mvc;
using WebApp.Filters;
namespace WebApp.Controllers
{
	//[WriteToConsoleResourceFilter]
	[MyHeaderFilter(Name = "xna",Value ="popop")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
