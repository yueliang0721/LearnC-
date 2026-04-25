using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApp.Helpers;
using WebApp.Model;

namespace WebApp.Filters
{
	public class EnsureModelActionFilter: ActionFilterAttribute
	{
		
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);
			var id = (int)context.ActionArguments["id"];//设计装拆箱 不过只有一次性能损耗不大
														//特性没办法使用依赖注入 只能通过context获取注册的服务
			var departmentrespository = context.HttpContext.RequestServices.GetService<IDepartmentRespository>();
			if(!departmentrespository.IsDepartmentExist(id))
			{
				//报错
				context.ModelState.AddModelError("id","Id is not validate");
				var view = new ViewResult() { ViewName = "Error"};

				//这里的ViewData是空的 必须通过控制器赋值
				var controller = context.Controller as Controller;
				view.ViewData = controller.ViewData;
				view.ViewData.Model = ModelStateHelper.GetErrors(context.ModelState);
				context.Result = view;
			}

		}
	}
}
