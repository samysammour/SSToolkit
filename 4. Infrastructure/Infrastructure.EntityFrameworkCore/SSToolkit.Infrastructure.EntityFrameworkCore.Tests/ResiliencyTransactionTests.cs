namespace SSToolkit.Infrastructure.EntityFrameworkCore.Tests
{
    using Xunit;
    using Shouldly;
    using SSToolkit.Fundamental.Extensions;
    using NSubstitute;
    using System;
    using System.Threading.Tasks;

    public class ResiliencyTransactionTests
    {
        [Fact]
        public async Task ResiliencyTransaction_Tests()
        {
            using (var context = new StubDbContext())
            {
                var transaction = Substitute.For<IResiliencyTransaction>();
                transaction.ExecuteAsync(Arg.Any<Func<Task>>()).Returns(async operation =>
                {
                    var func = operation[0] as Func<Task>;
                    await func().AnyContext();
                });

                transaction.ExecuteResultAsync(Arg.Any<Func<Task<string>>>()).ReturnsForAnyArgs(async operation =>
                {
                    var func = operation[0] as Func<Task<string>>;
                    return await func().AnyContext();
                });

                await transaction.ExecuteAsync(async () => Assert.True(true)).AnyContext();

                (await transaction.ExecuteResultAsync(async () => await Task.FromResult("Result").AnyContext()).AnyContext())
                    .ShouldNotBeNull().ShouldBe("Result");
            }
        }
    }
}
