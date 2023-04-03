namespace Psysup.WebApi.Middlewares.Error;

public static class ErrorHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorHandler(this WebApplication app)
    {
        return app.UseMiddleware<ErrorHandlerMiddleware>();
    }
}