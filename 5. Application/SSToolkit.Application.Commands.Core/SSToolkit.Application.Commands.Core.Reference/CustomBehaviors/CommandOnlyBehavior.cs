
namespace SSToolkit.Application.Commands.Core.Reference.CustomBehaviors
{
    using MediatR;
    using SSToolkit.Application.Commands.Core.Behaviors;
    using SSToolkit.Application.Commands.Core.Commands;
    using System.Threading;
    using System.Threading.Tasks;

    public class CommandOnlyBehavior<TRequest, TResponse> : BaseBehavior<TRequest, TResponse>
        where TRequest : class, ICommandRequest<TResponse>
    {
        public override async Task<TResponse> Process(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Console.WriteLine("Command only behavior");
            return await next().ConfigureAwait(false);
        }

        protected override bool CanProcess(TRequest request)
        {
            return true; // or conditional
        }
    }
}
