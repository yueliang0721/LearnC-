using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters
{
	//IOrderFilter可以改变过滤器的优先级 通过实现属性int Order来改变 默认都是0  数字越小优先级越大
	public class WriteToConsoleResourceFilter : Attribute ,IResourceFilter,IOrderedFilter//继承自attribute之后 可以直接作为特性使用
	{
		//默认执行顺序: 管道执行  全局执行->控制器执行->控制器方法执行->控制器方法执行结束->控制器执行结束->全局执行结束
		public string? Description { get; set; }

		public int Order { get; set; } = 0;

		public WriteToConsoleResourceFilter()
		{
			Description = "Global";
		}
		public void OnResourceExecuted(ResourceExecutedContext context)
		{
			Console.WriteLine($"过滤器执行{Description}之后:{context.ActionDescriptor.DisplayName}");
		}

		public void OnResourceExecuting(ResourceExecutingContext context)
		{
			
			Console.WriteLine($"过滤器执行{Description}中:{context.ActionDescriptor.DisplayName}");
		}
	}
}
