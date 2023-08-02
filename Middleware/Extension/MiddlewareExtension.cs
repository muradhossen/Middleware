using Middleware.Middleware;

namespace Middleware.Extension
{
    public static class MiddlewareExtension
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
