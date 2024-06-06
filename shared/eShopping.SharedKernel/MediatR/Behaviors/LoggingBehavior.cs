using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.Json;

namespace eShopping.SharedKernel.MediatR.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>(ILogger<Mediator> logger) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = request.GetType().Name;
            var requestGuid = Guid.NewGuid().ToString();

            var requestNameWithGuid = $"{requestName} [{requestGuid}]";

            logger.LogInformation($"[START] {requestNameWithGuid}");
            TResponse response;

            var stopwatch = Stopwatch.StartNew();
            try
            {
                try
                {
                    logger.LogInformation($"[PROPS] {requestNameWithGuid} {JsonSerializer.Serialize(request)}");
                }
                catch (NotSupportedException)
                {
                    logger.LogInformation($"[Serialization ERROR] {requestNameWithGuid} Could not serialize the request.");
                }

                response = await next();
            }
            finally
            {
                stopwatch.Stop();
                logger.LogInformation(
                    $"[END] {requestNameWithGuid}; Execution time={stopwatch.ElapsedMilliseconds}ms");
            }

            return response;
        }
    }
}