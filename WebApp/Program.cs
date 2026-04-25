using WebApp.Filters;
using WebApp.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(option =>
{
	option.Filters.Add<WriteToConsoleResourceFilter>();
});
builder.Services.AddRazorPages();
//builder.Services.AddRazorPages().AddMvcOptions(op =>
//{
//	op.Filters.Add<WriteToConsoleResourceFilter>()
//});
builder.Services.AddSingleton<IEmployeeRespository, EmployeeRespository>();
builder.Services.AddSingleton<IDepartmentRespository, departmentRespository>();
var app = builder.Build();

app.UseStaticFiles(
	new StaticFileOptions()
	{
		OnPrepareResponse = ctx =>
		{
			ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=600");
			ctx.Context.Response.Headers.Append("Expires",DateTime.UtcNow.AddMinutes(10).ToString("R"));
		}
	}
	);

app.UseRouting();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=index}/{id?}");

	endpoints.MapRazorPages();//razorpages自动导航 Pages文件夹视作根路径'/'
}
);

//对于这个小项目 ，MVC来控制department RazorPages来控制Employees

//MVCViews下的shared文件夹也可以共享给razorpages

app.Run();
