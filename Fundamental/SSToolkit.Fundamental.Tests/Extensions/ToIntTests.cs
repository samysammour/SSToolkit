namespace SSToolkit.Fundamental.Tests.Extensions
{
    using Fundamental.Extensions;
    using Shouldly;
    using Xunit;

    public partial class ToIntTests
    {
        [Fact]
        public void ToInt_Test()
        {
            ((string)null).ToInt().ShouldBe(0);
            ((string)null).ToInt(@default: 0).ShouldBe(0);

            ((string)null).ToNullableInt(@default: null).ShouldBeNull();

            string.Empty.ToInt().ShouldBe(0);
            string.Empty.ToInt(@default: 0).ShouldBe(0);

            "100".ToInt().ShouldBe(100);
            "wrong".ToDecimal().ShouldBe(0);
        }
    }
}
