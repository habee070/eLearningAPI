namespace eLearning.API.Middlewares;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class ExceptionHandlingMinddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMinddleware> _logger;

    public ExceptionHandlingMinddleware(RequestDelegate next,
        ILogger<ExceptionHandlingMinddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            //log the exception type and message
            _logger.LogError($"{ex.GetType().ToString()} : {ex.Message}");

            if (ex.InnerException is not null)
            {
                //log the inner exception type and message
                _logger.LogError($"{ex.InnerException.GetType().ToString()} : {ex.InnerException.Message}");
            }

            //set the response status code to 500 is internal server error
            httpContext.Response.StatusCode = 500;

            await httpContext.Response.WriteAsJsonAsync(new
            {
                Message = ex.Message,
                Type = ex.GetType().ToString()
            });
        }
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class ExceptionHandlingMinddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlingMinddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMinddleware>();
    }
}
