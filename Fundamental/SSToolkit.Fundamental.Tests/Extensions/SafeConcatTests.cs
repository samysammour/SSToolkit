namespace SSToolkit.Fundamental.Tests.Extensions
{
    using Fundamental.Extensions;
    using Shouldly;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class SafeConcatTests
	{
        [Fact]
		public void SafeConcat_Test()
		{
			var listToAdd = new List<string> { "item" };
			var itemToAdd = "item";

			((IEnumerable<string>)null).SafeConcat(itemToAdd).ShouldBe(listToAdd);
			((IEnumerable<string>)null).SafeConcat(listToAdd).ShouldBe(listToAdd);

			((IEnumerable<string>)new List<string> { }).SafeConcat(itemToAdd).ShouldBe(listToAdd);
			((IEnumerable<string>)new List<string> { }).SafeConcat(listToAdd).ShouldBe(listToAdd);

			((IList<string>)null).SafeConcat(itemToAdd).ShouldBe(listToAdd);
			((IList<string>)null).SafeConcat(listToAdd).ShouldBe(listToAdd);

			((IList<string>)new List<string> { }).SafeConcat(itemToAdd).ShouldBe(listToAdd);
			((IList<string>)new List<string> { }).SafeConcat(listToAdd).ShouldBe(listToAdd);

			((string[])null).SafeConcat(itemToAdd).ShouldBe(listToAdd);
			((string[])null).SafeConcat(listToAdd).ShouldBe(listToAdd);

			new string[] { }.SafeConcat(itemToAdd).ShouldBe(listToAdd);
			new string[] { }.SafeConcat(listToAdd).ShouldBe(listToAdd);
		}
	}
}
