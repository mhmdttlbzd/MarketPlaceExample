using MarketPlace.Domain.Core.Application.Contract.Services.Log;
using MarketPlace.Domain.Core.Application.Entities._log;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Diagnostics;

namespace MarketPlace.Domain.AppServices.Midllewares
{
    public class ErrorLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IErrorLogService _ErrorLogService;
        public ErrorLogMiddleware(RequestDelegate next, IErrorLogService errorLogService)
        {
            _next = next;
            _ErrorLogService = errorLogService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Call the next delegate/middleware in the pipeline.
            try
            {
                await _next(context);
            }
            catch(Exception exception)
            {
                
                var frame = new StackTrace(exception, true)?.GetFrame(0);
                var errorCode = new Random().Next(100000,999999);
                var properties = new Dictionary<string, string?>();
                properties.Add("ExeptionType", exception?.GetType()?.Name);
                properties.Add("ErrorFilePath", $"File : {frame?.GetFileName()}");
                properties.Add("ExceptionSource", exception?.Source);
                properties.Add("Message", exception?.Message);
                properties.Add("MethodPath", exception?.TargetSite?.DeclaringType?.FullName);
                properties.Add("UserName", context.User?.Identity?.Name);
                properties.Add("Stacktrace", $"{exception?.StackTrace} - {exception?.InnerException?.StackTrace}");
                properties.Add("InnerExeption", exception?.InnerException?.Message);

                await _ErrorLogService.LogError(properties, errorCode);
                context.Response.Redirect($"/Home/Error?errorCode={errorCode}");
                
            }
            
        }
    }
}
