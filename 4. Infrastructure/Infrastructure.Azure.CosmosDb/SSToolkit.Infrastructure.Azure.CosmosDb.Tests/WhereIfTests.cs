namespace SSToolkit.Infrastructure.Azure.CosmosDb.Tests
{
    using System.Collections.Generic;
    using Xunit;
    using SSToolkit.Infrastructure.Azure.CosmosDb.Extensions;
    using System.Linq;
    using Shouldly;
    using System.Linq.Expressions;
    using System;

    public class WhereIfTests
    {
        [Fact]
        public void WhereIf_Test()
        {
            var list = new List<string> { "Item 1", "Item 2", "Item 3" };
            var result = list.AsQueryable().WhereIf(null as Expression<Func<string, bool>>);
            result.ShouldNotBeNull();
            result.Count().ShouldBe(list.Count);

            result = list.AsQueryable().WhereIf(x => x == "Item 1" || x == "Item 2");
            result.ShouldNotBeNull();
            result.Count().ShouldBe(2);
            result.First().ShouldBe("Item 1");
            result.Last().ShouldBe("Item 2");
        }
    }
}