namespace SSToolkit.Fundamental.Tests.Extensions
{
    using Fundamental.Extensions;
    using Shouldly;
    using System.Collections.Generic;
    using Xunit;

    public class SafeAnyTests
    {
        [Fact]
		public void SafeAny_Test()
		{
			(null as List<string>).SafeAny().ShouldBeFalse();
			new List<string>().SafeAny().ShouldBeFalse();
			new List<string>()
			{
				"Item2",
			}.SafeAny().ShouldBeTrue();

			new List<string>()
			{
				"Item",
				"Item2",
			}.SafeAny(x => x == "Item2").ShouldBeTrue();
			new List<string>()
			{
				"Item",
				"Item2",
			}.SafeAny(x => x == "Item3").ShouldBeFalse();
		}
	}
}
