using Microsoft.AspNetCore.Builder;

namespace SharpGamingAPI.Common.Exceptions
{
    public static class RegisterExceptionHandler
    {
        public static void ExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandler>();
        }
    }
}
