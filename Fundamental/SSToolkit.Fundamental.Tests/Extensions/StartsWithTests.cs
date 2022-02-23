namespace SSToolkit.Fundamental.Tests.Extensions
{
    using Fundamental.Extensions;
    using Shouldly;
    using System.Collections.Generic;
    using Xunit;

    public partial class StartsWithTests
    {
        [Fact]
        public void StartsWith_Test()
        {
            ((string)null).StartsWithAny(new List<string> { "hello" }).ShouldBeFalse();
            string.Empty.StartsWithAny(new List<string> { "hello" }).ShouldBeFalse();
            "hello world".StartsWithAny(null).ShouldBeFalse();
            "hello world".StartsWithAny(new List<string> { }).ShouldBeFalse();
            "hello world".StartsWithAny(new List<string> { "hello" }).ShouldBeTrue();
            "hello world".StartsWithAny(new List<string> { "hi", "hello" }).ShouldBeTrue();
        }
    }
}
