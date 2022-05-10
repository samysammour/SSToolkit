namespace SSToolkit.Fundamental.Tests.Extensions
{
    using Fundamental.Extensions;
    using Shouldly;
    using Xunit;

    public class SliceTests
    {
        [Fact]
        public void Slice_Positions()
        {
            ((string)null).Slice("start", "end").ShouldBeNull();
            "cut from string to string".Slice("from", "to").ShouldBe(" string ");

            "cut from string to string".Slice(0, 3).ShouldBe("cut");
            "cut from string to string".Slice(0, 50).ShouldBe("cut from string to string");
        }
    }
}
