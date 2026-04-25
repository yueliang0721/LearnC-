using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters
{
	public class DateExpiredFilter : Attribute, IResourceFilter
	{
		public string? ExpiredTime { get; set; }
		public void OnResourceExecuting(ResourceExecutingContext context)
		{
			if(DateTime.TryParse(ExpiredTime, out var date))
			{
				if(DateTime.Now > date)
				{
					context.Result = new BadRequestResult();
				}
			}
		}
		public void OnResourceExecuted(ResourceExecutedContext context)
		{
		}

	}
}
