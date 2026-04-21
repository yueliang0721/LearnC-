
using System.Reflection.Metadata.Ecma335;
using WebApplication1.Model;

namespace WebApplication1.filter
{
	public class EmployeeUpdateFilter : IEndpointFilter
	{
		public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
		{
			var id = context.GetArgument<int>(0);
			var Employee = context.GetArgument<Employee>(1);

			if(id != Employee.Id)
			{
				return Results.ValidationProblem(new Dictionary<string, string[]>()
				{
					{"Error",new[]{"Id is not Validate!"} }
				},statusCode:404);
			}

			return await next(context);
		}
	}
}
