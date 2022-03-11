namespace SSToolkit.Fundamental
{
    using System.Threading.Tasks;
    using Shouldly;
    using SSToolkit.Fundamental.Extensions;
    using Xunit;

    public class ScopedTransactionTests
    {
        [Fact]
        public async Task ToDescription_Test()
        {
            var transaction = new ScopedTransaction();

            // Async
            await transaction.ExecuteAsync(async () =>
            {
                Assert.True(true);
            }).AnyContext();

            // Sync
            transaction.ExecuteAsync(async () =>
            {
                Assert.True(true);
            }).Wait();

            // With result
            var result = await transaction.ExecuteResultAsync(async () =>
            {
                return await Task.FromResult("Result").AnyContext();
            }).AnyContext();

            result.ShouldNotBeNull();
            result.ShouldBe("Result");
        }
    }
}
