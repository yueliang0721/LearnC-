using WebApplication1.Model;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<ResponseMiddleware>();

//AddTransient是瞬态 每次请求接口的时候都会创建新的对象
//AddScoped是作用域  伴随着httpcontext请求创建 然后摧毁
//AddSingleton是单例 服务器开着就一只获取同一个对象

builder.Services.AddSingleton<IEmployeeResposity,EmployeeResposity>();//注册接口 每当访问接口的时候 实例化一个员工仓库对象
builder.Services.AddProblemDetails();
var app = builder.Build();

if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}

app.UseStatusCodePages();

app.UseMiddleware<ResponseMiddleware>();

app.MapEmployeeEndpoints();

app.Run();
