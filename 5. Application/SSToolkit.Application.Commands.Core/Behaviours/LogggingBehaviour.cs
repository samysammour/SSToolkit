namespace SSToolkit.Application.Commands.Core
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using SSToolkit.Fundamental.Extensions;

    public class LogggingBehaviour<TRequest, TResponse> : QueryBaseBehaviour<TRequest, TResponse>
        where TRequest : class, IQueryRequest<TResponse>
    {
        private readonly ILogger logger;

        public LogggingBehaviour(ILogger logger)
            : base()
        {
            this.logger = logger;
        }

        protected override bool CanProcess(TRequest request)
        {
            return true; // This Behaviour should be applied for all requests when needed. Not specified per request
        }

        public override async Task<TResponse> Process(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Processing Query {0}", request.GetType().Name);
            var response  = await this.Process(request, next, cancellationToken).AnyContext();
            this.logger.LogInformation("Query processed {0}", request.GetType().Name);

            return response;
        }
    }
}
