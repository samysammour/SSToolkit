namespace SSToolkit.Fundamental.Tests.Extensions
{
    using Fundamental.Extensions;
    using Shouldly;
    using Xunit;

    public partial class SubstringFromTests
    {
        [Fact]
        public void SubstringFrom_Test()
        {
            ((string)null).SubstringFrom("hello").ShouldBeNull();
            string.Empty.SubstringFrom("hello").ShouldBeEmpty();
            string.Empty.SubstringFrom(null).ShouldBeEmpty();
            string.Empty.SubstringFrom(string.Empty).ShouldBeEmpty();

            "aaa.bbb.aaa.bbb".SubstringFrom("bbb").ShouldBe(".aaa.bbb");
            "aaa.bbb.aaa.bbb".SubstringFromLast("aaa").ShouldBe(".bbb");
        }
    }
}
