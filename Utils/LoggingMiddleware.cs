using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace RouteMatching.Utils
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Serilog.ILogger log;

        public LoggingMiddleware(RequestDelegate next, Serilog.ILogger log)
        {
            _next = next;
            this.log = log;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            
            log.Information("Request, Path: {Path}, Method: {Method} Headers: {@Headers}", context.Request.Path, context.Request.Method,context.Request.Headers);

            await _next(context);

            log.Information("Response for request Path: {Path}, Method: {Method} Headers: {@Headers}", context.Request.Path, context.Request.Method, context.Request.Headers);
            log.Information("Respone Status code:{StatusCode}", context.Response.StatusCode);

        }
    }

    public static class LoggingMiddlewareMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogging(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
