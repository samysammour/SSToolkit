namespace SSToolkit.Application.Commands.Core.Behaviors
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.Extensions.Logging;

    public class LoggingBehavior<TRequest, TResponse> : BaseBehavior<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
            : base()
        {
            this.logger = logger;
        }

        protected override bool CanProcess(TRequest request)
        {
            // This Behaviour should be applied for all requests when needed. Not specified per request
            return true; 
        }

        public override async Task<TResponse> Process(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            this.CanProcess(request);
            this.logger.LogInformation($"Processing request {request.GetType().Name}");
            var response = await next().ConfigureAwait(false);
            this.logger.LogInformation($"Request processed {request.GetType().Name}");

            return response;
        }
    }
}
