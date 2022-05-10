namespace SSToolkit.Application.Commands.Core
{
    using System;
    using MediatR;

    public interface IQueryRequest<TResponse> : IRequest<TResponse>
    {
        /// <summary>
        /// Gets or sets a unique request Id
        /// </summary>
        Guid RequestId { get; }
    }
}
