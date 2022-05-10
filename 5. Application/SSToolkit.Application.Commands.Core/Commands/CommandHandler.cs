﻿namespace SSToolkit.Application.Commands.Core
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public abstract class CommandHandler<TRequest> : IRequestHandler<TRequest, CommandResponse>
        where TRequest : class, ICommandRequest<CommandResponse>
    {
        protected CommandHandler()
        {
        }

        /// <summary>
        /// Handle method
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<CommandResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new CommandResponse("Request cannot be null");
            }

            var response = await this.Process(request, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Process method (Should be implemented)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task<CommandResponse> Process(TRequest request, CancellationToken cancellationToken);
    }

    public abstract class CommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, CommandResponse<TResponse>>
        where TRequest : class, ICommandRequest<CommandResponse<TResponse>>
    {
        protected CommandHandler()
        {
        }

        /// <summary>
        /// Handle method
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<CommandResponse<TResponse>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new CommandResponse<TResponse>("Request cannot be null");
            }
            
            var response = await this.Process(request, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Process method (Should be implemented)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task<CommandResponse<TResponse>> Process(TRequest request, CancellationToken cancellationToken);
    }
}
