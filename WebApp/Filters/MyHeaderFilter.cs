using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters
{
	public class MyHeaderFilter : Attribute, IResultFilter
	{
		public string? Name { get; set; }
		public String? Value { get; set; }
		public void OnResultExecuted(ResultExecutedContext context)
		{
		}

		public void OnResultExecuting(ResultExecutingContext context)
		{
			if (context.HttpContext.Response is not null &&
				this.Name is not null &&
				this.Value is not null &&
				context.HttpContext.Response.Headers is not null &&
				!context.HttpContext.Response.Headers.ContainsKey(Name))
			{
				context.HttpContext.Response!.Headers!.Add(Name, Value);
			}
		}
	}
}
