using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api
{
     public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;


        public ExceptionMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;
        }

        public async Task Invoke(HttpContext context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    await _next(context);
                }
                catch (Exception ex)
                {
                    // var errorLogs = scope.ServiceProvider.GetRequiredService<BusinessLogic.Interfaces.IErrorLogs>();
                    // await errorLogs.SaveErrorLogAsync(ex);
                    await HandleExceptionAsync(context, ex);
                }
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            // Return the error details
            /*var result = JsonConvert.SerializeObject(new
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            });*/
            await context.Response.WriteAsync(exception.Message);
        }
    }
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}