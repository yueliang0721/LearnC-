using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApp.Helpers;

namespace WebApp.Filters
{
	public class EnsureModelValidateFilter:ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);

			if(!context.ModelState.IsValid)//模型状态不正常
			{
				var view = new ViewResult() { ViewName = "Error"};
				view.ViewData = (context.Controller as Controller).ViewData;
				view.ViewData.Model = ModelStateHelper.GetErrors(context.ModelState);
				context.Result = view;
			}
		}
	}
}
