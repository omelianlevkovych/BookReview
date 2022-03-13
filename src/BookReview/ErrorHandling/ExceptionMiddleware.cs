using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BookReview.ErrorHandling
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch(ApplicationException exception)
            {
                logger.Error($"Application exception has been thrown {exception}");
                await HandleExceptionAsync(httpContext, exception);
            }
            catch(Exception exception)
            {
                logger.Error(exception.ToString());
                await HandleExceptionAsync(httpContext, exception);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = GetStatusCode(exception);
;
            await context.Response
                .WriteAsync(new ErrorDetails(context.Response.StatusCode)
                    .ToString());
        }

        private static int GetStatusCode(Exception exception)
        {
            int code = (int)HttpStatusCode.InternalServerError;
            if (exception is NotFoundException)
            {
                code = (int)HttpStatusCode.NotFound;
            }
            return code;
        }
    }
}
