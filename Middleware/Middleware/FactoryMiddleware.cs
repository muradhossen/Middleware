namespace Middleware.Middleware
{
    public class FactoryMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine("Factory middleware before next...");

            await next(context);

            Console.WriteLine("Factory middleware after next...");

        }
    }
}
