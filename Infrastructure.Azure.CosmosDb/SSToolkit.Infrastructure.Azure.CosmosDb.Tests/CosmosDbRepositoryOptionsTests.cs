namespace SSToolkit.Infrastructure.Azure.CosmosDb.Tests
{
    using System.Collections.Generic;
    using Xunit;
    using SSToolkit.Fundamental.Extensions;
    using SSToolkit.Infrastructure.Azure.CosmosDb.Extensions;
    using System.Linq;
    using Shouldly;
    using System.Linq.Expressions;
    using System;

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