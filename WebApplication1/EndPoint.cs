using Microsoft.AspNetCore.Mvc;
using WebApplication1.filter;
using WebApplication1.Model;

namespace WebApplication1
{

    //实现对WebApplication的扩展
    public static class EndPoints
    {
        public static void MapEmployeeEndpoints(this WebApplication app)
        {
            //全都用body传递
            app.MapGet("/", (IEmployeeResposity employeeResposity) =>
            {
                Console.WriteLine("Excute ");
                return TypedResults.Ok(employeeResposity.GetEmployees());
            }).AddEndpointFilter(async (context, next) =>
            {
                Console.WriteLine("A");
                var res = await next(context);
                Console.WriteLine("~A");
                return res;
            }).AddEndpointFilter(async (context, next) =>
			{
				Console.WriteLine("B");
				var res = await next(context);
                Console.WriteLine("~B");
                return res;
            }).AddEndpointFilter(async (context, next) =>
			{
				Console.WriteLine("C");
				var res = await next(context);
                Console.WriteLine("~C");
                return res;
            });


            app.MapPost("/Create", ([FromBody]Employee employee,IEmployeeResposity employeeResposity) =>
            {
                employeeResposity.AddEmployee(employee);
                return TypedResults.Created($"/Employee/{employee.Id}",employee);
            }).WithParameterValidation();

            app.MapDelete("/Delete/{id:int}", ([FromRoute]int id,IEmployeeResposity emres) =>
            {
                emres.DeleteEmployeeById(id);
                
                return Results.Ok("删除成功");
                
            }).AddEndpointFilter<EmployeeDeleteFilter>();

            app.MapGet("/Employee/{id:int}",([FromRoute]int id,IEmployeeResposity emp) =>
            {
                Employee? employee = emp.GetEmployeeById(id);
                if (employee != null)
                {
                    return Results.Ok(employee);
                }
                else
                {
                    return TypedResults.Problem(statusCode:400,detail:"没有这个id的员工",title:"id错误");
                }

            });

            app.MapPut("/Updata/{id:int}", ([FromRoute] int id, [FromBody] Employee employee, IEmployeeResposity emp) =>
            {
                emp.Updata(id, employee);
                return TypedResults.Ok("执行成功");
            }).WithParameterValidation().AddEndpointFilter<EmployeeUpdateFilter>();
            //可以把这个withparametervalidation看成一个过滤器，先执行参数验证，然后再执行我自创的过滤器


            //}).AddEndpointFilter(async (context, next) =>
            //{
            //    var id = context.GetArgument<int>(0);
            //    var employee = context.GetArgument<Employee>(1);
            //    if(id != employee.Id)
            //    {
            //        return Results.ValidationProblem(new Dictionary<string, string[]>()
            //        {
            //            {"Error!!!!!:",new string[]{"Id Error not Match!!!"} }
            //        });
            //    }
            //    return await next(context);
            //});

        }
    }
}
