using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;


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
              

                await _next.Invoke(context);



                string json = JsonSerializer.Serialize(new { response = "My message " });

                await context.Response.WriteAsync(json);

            }
            catch (Exception ex)
            {

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync("Internal Server Error!" );
                throw;
            }
        }
    }
}
