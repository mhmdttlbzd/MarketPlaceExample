using Microsoft.AspNetCore.Builder;

namespace MarketPlace.Domain.AppServices.Midllewares
{
    public static class CustomMidllewaresMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMidllewares(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ViewLogMiddleware>();
        }
    }
}
