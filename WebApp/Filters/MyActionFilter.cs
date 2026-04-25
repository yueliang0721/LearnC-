using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters
{
	public class MyActionFilter:ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			Console.WriteLine($"{context.ActionDescriptor.DisplayName}Actionfilter正在执行");
		}
	}
}
