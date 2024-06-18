
namespace Restaurants.API.Middleware;

    //creating custome error handling middelware
    public class ErrorHandlingMiddelware(ILogger<ErrorHandlingMiddelware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);

            }catch (Exception ex)
            {
                logger.LogError(ex,ex.Message);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(ex.Message);
               
            }
        }
}
