using Psysup.DataContracts;
using Psysup.Domain.Exceptions.Base;
using Psysup.Domain.Exceptions.Common;

namespace Psysup.WebApi.Middlewares.Error;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var restException = exception as RestException ?? new NonGeneralException(exception.Message);

        context.Response.StatusCode = (int)restException.StatusCode;

        var errorResponse = new ErrorResponse
        {
            Code = restException.Code,
            Message = restException.Message,
            Description = restException.Description
        };

        await context.Response.WriteAsJsonAsync(errorResponse);
    }
}