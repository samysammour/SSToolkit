namespace SSToolkit.Fundamental.Tests.Extensions
{
    using Fundamental.Extensions;
    using Shouldly;
    using Xunit;

    public class RemoveTests
    {
        [Fact]
        public void Remove_Test()
        {
            "To remove this".Remove("remove").ShouldBe("To  this");
        }
    }
}
