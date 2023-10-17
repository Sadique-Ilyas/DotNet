namespace WebApi_.NetCore.Middlewares
{
	public class CustomMiddleware : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			await context.Response.WriteAsync("CustomMiddleware\n");
			await next(context);
			await context.Response.WriteAsync("CustomMiddleware\n");
		}
	}
}
