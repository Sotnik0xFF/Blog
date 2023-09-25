using Blog.Models.DB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Blog.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestRepository _repository;

        public LoggingMiddleware(RequestDelegate next, IRequestRepository repository)
        {
            _next = next;
            _repository = repository;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string protocol = httpContext.Request.IsHttps ? "https://" : "http://";
            string path = protocol + httpContext.Request.Host.Value + httpContext.Request.Path;

            Console.WriteLine($"[{DateTime.Now}]: New request to {path}");

            Request request = new Request() { Url = path, Date = DateTime.Now};
            await _repository.Add(request);

            await _next(httpContext);
        }
    }

    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
