namespace SSToolkit.Application.Commands.Core.Reference.CustomBehaviors
{
    using MediatR;
    using SSToolkit.Application.Commands.Core.Behaviors;
    using SSToolkit.Application.Commands.Core.Queries;
    using System.Threading;
    using System.Threading.Tasks;

    public class ConditionalBehavior<TRequest, TResponse> : BaseBehavior<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
    {
        public override async Task<TResponse> Process(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Console.WriteLine("Conditional behavior");
            return await next().ConfigureAwait(false);
        }

        protected override bool CanProcess(TRequest request)
        {
            return request is IConditional;
        }
    }
}
