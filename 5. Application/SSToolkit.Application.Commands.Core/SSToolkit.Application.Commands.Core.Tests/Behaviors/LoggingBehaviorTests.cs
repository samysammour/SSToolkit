using NSubstitute;
using SSToolkit.Application.Commands.Core.Behaviors;
using SSToolkit.Application.Commands.Core.Commands;
using Microsoft.Extensions.Logging;
using Xunit;
using System.Threading;
using System.Threading.Tasks;

namespace SSToolkit.Application.Commands.Core.Tests.Behaviors
{
    public class LoggingBehaviorTests
    {
        private readonly ILogger<LoggingBehavior<StubCommand, CommandResponse>> logger;

        public LoggingBehaviorTests()
        {
            this.logger = Substitute.For<ILogger<LoggingBehavior<StubCommand, CommandResponse>>>();
        }

        [Fact]
        public void LoggingBehavior_Tests()
        {
            // Arrange
            var behavior = new LoggingBehavior<StubCommand, CommandResponse>(this.logger);

            // Act
            behavior.Process(new StubCommand(), () => Task.FromResult(new CommandResponse()), CancellationToken.None).Wait();

            // Asserts
            this.logger.Received(2);
            this.logger.Received(1).LogInformation("Processing request StubCommand");
            this.logger.Received(1).LogInformation("Request processed StubCommand");
        }
    }

    public class StubCommand : CommandRequest
    {
    }
}
