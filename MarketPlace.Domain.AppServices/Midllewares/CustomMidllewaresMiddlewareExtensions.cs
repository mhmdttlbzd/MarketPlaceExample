using Microsoft.AspNetCore.Builder;

namespace MarketPlace.Domain.AppServices.Midllewares
{
    public static class CustomMidllewaresMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMidllewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorLogMiddleware>();
            app.UseMiddleware<ViewLogMiddleware>();
            return app;
        }
    }
}
