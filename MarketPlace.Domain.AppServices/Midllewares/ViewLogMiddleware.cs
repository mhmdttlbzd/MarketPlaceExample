using MarketPlace.Domain.Core.Application.Contract.Services.Log;
using Microsoft.AspNetCore.Http;

namespace MarketPlace.Domain.AppServices.Midllewares
{
    public class ViewLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IViewLogService _viewLogService;
        public ViewLogMiddleware(RequestDelegate next, IViewLogService viewLogService)
        {
            _next = next;
            _viewLogService = viewLogService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Call the next delegate/middleware in the pipeline.
            _viewLogService.LogView();
            await _next(context);
        }
    }    }
