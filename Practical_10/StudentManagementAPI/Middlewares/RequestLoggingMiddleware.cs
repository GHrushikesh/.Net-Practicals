using System.Diagnostics;

namespace StudentManagementAPI.Middlewares
{
    /// <summary>
    /// Custom middleware to log incoming HTTP requests, response status code, and execution time.
    /// Demonstrates the ASP.NET Core Request Processing Pipeline.
    /// </summary>
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            var requestMethod = context.Request.Method;
            var requestPath = context.Request.Path;
            var queryString = context.Request.QueryString.HasValue ? context.Request.QueryString.Value : string.Empty;

            _logger.LogInformation("[HTTP REQUEST] Method: {Method} | Path: {Path}{Query} | Time: {Timestamp}",
                requestMethod, requestPath, queryString, DateTime.UtcNow);

            try
            {
                // Call the next middleware in the pipeline
                await _next(context);
            }
            finally
            {
                stopwatch.Stop();
                var statusCode = context.Response.StatusCode;

                _logger.LogInformation("[HTTP RESPONSE] Method: {Method} | Path: {Path} | Status: {StatusCode} | Elapsed: {Elapsed}ms",
                    requestMethod, requestPath, statusCode, stopwatch.ElapsedMilliseconds);
            }
        }
    }

    public static class RequestLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}
