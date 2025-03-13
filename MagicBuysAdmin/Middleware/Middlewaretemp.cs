using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MagicBuysAdmin.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middlewaretemp
    {
        private readonly RequestDelegate _next;

        public Middlewaretemp(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.WriteAsync("custom middleware start from template without async\n");

             _next(httpContext);

            httpContext.Response.WriteAsync("custom middleware end from template without async\n");

            return Task.CompletedTask;

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewaretempExtensions
    {
        public static IApplicationBuilder UseMiddlewaretemp(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middlewaretemp>();
        }
    }
}
