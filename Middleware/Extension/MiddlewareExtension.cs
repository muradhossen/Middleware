using Middleware.Middleware;

namespace Middleware.Extension
{
    public static class MiddlewareExtension
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder builder)
        {

            #region Request Delegate

            builder.Use(async (context, next) =>
            {

                Console.WriteLine("Before..");

                await next.Invoke();

                Console.WriteLine("After...");
            });
            builder.Use(async (context, next) =>
            {

                Console.WriteLine("Before...");

                await next.Invoke();

                Console.WriteLine("After...");
            });
            #endregion

            #region Convention
            builder.UseMiddleware<ExceptionMiddleware>();

            #endregion

            #region Factory
            builder.UseMiddleware<FactoryMiddleware>();

            #endregion

        }
    }
}
