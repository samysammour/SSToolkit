namespace SSToolkit.Infrastructure.Azure.CosmosDb.Tests
{
    using Xunit;
    using Shouldly;

    public class CosmosDbRepositoryOptionsTests
    {
        [Fact]
        public void GetPartitionKey_Test()
        {
            var options = new CosmosDbRepositoryOptions<Stub>()
            {
                PartitionKey = "Age"
            };

            options.GetPartitionKey().ShouldBe("Age");

            options.PartitionKeyExpression = x => x.Location;
            options.GetPartitionKey().ShouldBe("Age");

            options.PartitionKey = null;
            options.GetPartitionKey().ShouldBe("Location");
        }
    }
}