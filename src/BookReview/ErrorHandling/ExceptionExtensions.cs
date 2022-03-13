using Microsoft.AspNetCore.Builder;

namespace BookReview.ErrorHandling
{
    public static class ExceptionExtensions
    {
        public static void UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
