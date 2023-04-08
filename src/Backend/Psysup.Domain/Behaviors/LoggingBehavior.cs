using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Psysup.Domain.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private const string BeginRequestTemplate = "Begin Request ID: {uniqueId}, Request Name: {requestName}";

    private const string EndRequestTemplate =
        "End Request ID: {uniqueId}, Request Name: {requestName}, Total Request Time: {totalTime}";

    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var uniqueId = Guid.NewGuid();
        var stopWatch = new Stopwatch();

        try
        {
            _logger.LogInformation(BeginRequestTemplate, uniqueId, requestName);

            stopWatch.Start();
            var response = await next();
            stopWatch.Stop();

            _logger.LogInformation(EndRequestTemplate, uniqueId, response, stopWatch.Elapsed);

            return response;
        }
        catch (Exception exception)
        {
            stopWatch.Stop();
            _logger.LogError(exception, EndRequestTemplate, uniqueId, requestName, stopWatch.Elapsed);
            throw;
        }
    }
}