using System.Net;
using web_api.Error;

namespace web_api.Middlewares
{
    public class ExceptionMiddleware
    {
        public readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IHostEnvironment env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }

            catch (Exception ex)
            {
                ApiError response;
                string message;
                HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
                var exceptionType = ex.GetType();

                if (exceptionType == typeof(UnauthorizedAccessException))
                {
                    statusCode = HttpStatusCode.Forbidden;
                    message = "You are not authorized";
                } else
                {
                    statusCode = HttpStatusCode.InternalServerError;
                    message = "Some unknown error occured";
                }


                if (env.IsDevelopment())
                {
                    response = new ApiError((int)statusCode, ex.Message, ex.StackTrace.ToString());
                } else
                {
                    response = new ApiError((int)statusCode, message);
                }
                logger.LogError(ex,ex.Message);
                context.Response.StatusCode = (int) statusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(response.ToString());
            }
        }

    }
}
