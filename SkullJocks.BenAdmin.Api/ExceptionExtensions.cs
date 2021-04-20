using Microsoft.AspNetCore.Builder;

namespace SkullJocks.BenAdmin.Api
{
    public static class ExceptionExtensions
    {
        public static IApplicationBuilder UseExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandler>();
        }
    }
}

