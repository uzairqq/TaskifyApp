using Newtonsoft.Json;
using System.Net;
using TaskifyApp.Models;

namespace TaskifyApp.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var errorResponse = new ErrorResponse
            {
                Message = ex.Message,
                StatusCode = ((int)HttpStatusCode.InternalServerError).ToString(),
                ErrorDetails = ex.StackTrace
            };

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
        }
    }
}
