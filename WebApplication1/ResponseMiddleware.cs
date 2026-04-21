
namespace WebApplication1
{
    public class ResponseMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Response.ContentType = "text/plain;charset=utf-8";

            await next(context);
        }
    }
}
