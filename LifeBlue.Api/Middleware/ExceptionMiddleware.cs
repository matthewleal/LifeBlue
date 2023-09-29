using System.Text.Json;
using LifeBlue.Core.Constants;

namespace LifeBlue.Api.MIddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ExceptionConstants.ErrorMessage);
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = ExceptionConstants.ContentType;
            context.Response.StatusCode = ExceptionConstants.ErrorStatusCode;
            context.Response.Headers.Add(ExceptionConstants.AllowOriginHeader, ExceptionConstants.AllowOriginHeaderValue);

            return context.Response.WriteAsync(WriteResponseString(exception));
        }

        private string WriteResponseString(Exception ex)
        {
            return JsonSerializer.Serialize(new
            {
                Success = false,
                ErrorMessage = ex.Message,
                InnerException = ex?.InnerException?.Message
            });
        }
    }

    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
