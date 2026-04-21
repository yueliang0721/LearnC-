
namespace WebApplication1.filter
{
	//net 9.0新的语法糖   直接在类上构造私有字段  依赖注入不要太爽
	public class EmployeeDeleteFilter(IEmployeeResposity employeeResposity) : IEndpointFilter
	{

		public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
		{
			var id = context.GetArgument<int>(0);

			if(employeeResposity.GetEmployeeById(id) is null)
			{
				return Results.ValidationProblem(new Dictionary<string, string[]>()
				{
					{"Error",new string[]{"Id is not exist"} }
				});
			}

			return await next(context);
		}
	}
}
