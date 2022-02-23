namespace SSToolkit.Fundamental.Tests.Extensions
{
    using Fundamental.Extensions;
    using Shouldly;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public partial class ToStringTests
    {
        [Fact]
        public void ToString_Test()
        {
            ((IEnumerable<string>)null).ToString(";").ShouldBeEmpty();
            Enumerable.Empty<string>().ToString(";").ShouldBeEmpty();

            new List<string>() { "first", "second" }.ToString(";").ShouldBe("first;second");
            new List<string>() { "first", "second" }.ToString(" - ").ShouldBe("first - second");
        }
    }
}
