using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters
{
	public class WebApiEndpointFilter:ExceptionFilterAttribute
	{
		public override void OnException(ExceptionContext context)
		{
			base.OnException(context);

			var error = new ProblemDetails()
			{
				Title = "Error",
				Detail = "This is an Occured Error!",
				Status = 500
			};

			context.Result = new ObjectResult(error)
			{
				StatusCode = 500
			};

			context.ExceptionHandled = true;//这一行代码告诉net core框架 这个异常已经被处理过了 不需要再被处理

		}
	}
}
