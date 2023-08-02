using System.Net;


namespace Middleware.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                Console.WriteLine("Custom middleware before next invoke...");

                await _next.Invoke(context);

                Console.WriteLine("Custom middleware after next invoke...");
            }
            catch (Exception ex)
            {

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync("Internal Server Error!");
                throw;
            }
        }
    }
}
