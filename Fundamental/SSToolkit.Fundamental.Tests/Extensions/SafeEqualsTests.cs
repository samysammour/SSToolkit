namespace SSToolkit.Fundamental.Tests.Extensions
{
    using Fundamental.Extensions;
    using Shouldly;
    using Xunit;

    public class SafeEqualsTests
    {
        [Fact]
        public void SafeEquals_Test()
        {
            ((string)null).SafeEquals("val").ShouldBeFalse();
            (string.Empty).SafeEquals("val").ShouldBeFalse();
            ("val").SafeEquals("val").ShouldBeTrue();
            ("val").SafeEquals("VaL").ShouldBeTrue();
            ("val1").SafeEquals("VaL").ShouldBeFalse();
        }
    }
}
