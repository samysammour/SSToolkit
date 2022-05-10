namespace SSToolkit.Application.Commands.Core
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public abstract class QueryBaseBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
         where TRequest : class, IQueryRequest<TResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBaseBehaviour{TRequest, TResponse}"/> class.
        /// </summary>
        protected QueryBaseBehaviour()
        {
        }

        /// <summary>
        /// Handle method
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!this.CanProcess(request))
            {
                return await next().ConfigureAwait(false);
            }

            return await this.Process(request, next, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Write conditions when the pipeline behaviour should be activated (Should be implemented)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected abstract bool CanProcess(TRequest request);
        
        /// <summary>
        /// Process method (Should be implemented)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task<TResponse> Process(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken);
    }
}
