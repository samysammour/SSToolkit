namespace SSToolkit.Fundamental.Tests.Extensions
{
    using Fundamental.Extensions;
    using Shouldly;
    using System;
    using Xunit;

    public class IsGuidNullOrEmptyTests
    {
        [Fact]
        public void IsGuidNullOrEmpty_Test()
        {
            ((Guid?)null).IsGuidNullOrEmpty().ShouldBeTrue();
            (Guid.Empty).IsGuidNullOrEmpty().ShouldBeTrue();
            (Guid.NewGuid()).IsGuidNullOrEmpty().ShouldBeFalse();
        }
    }
}
