using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bookify.Application.Abstractions.Behaviors;

internal sealed class LoggingBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseCommand
{
    private readonly ILogger<TRequest> _logger;

    public LoggingBehavior(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        string requestName = request.GetType().Name;

        try
        {
            _logger.LogInformation("Executing command {Command}", requestName);

            TResponse result = await next();

            _logger.LogInformation("command {Command} processed successfully", requestName);
         
            return result;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "command {Command} processing failed", requestName);

            throw;
        }
    }
}
