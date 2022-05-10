namespace SSToolkit.Fundamental.Tests.Extensions
{
    using Fundamental.Extensions;
    using Shouldly;
    using Xunit;

    public partial class ToBoolTests
    {
        [Fact]
        public void ToBool_Test()
        {
            ((string)null).ToBool().ShouldBeFalse();
            ((string)null).ToBool(@default: true).ShouldBeTrue();

            ((string)null).ToNullableBool(@default: null).ShouldBeNull();

            string.Empty.ToBool().ShouldBeFalse();
            string.Empty.ToBool(@default: true).ShouldBeTrue();

            "true".ToBool().ShouldBeTrue();
            "true".ToBool(@default:true).ShouldBeTrue();
            "true".ToBool(@default: false).ShouldBeTrue();

            "false".ToBool().ShouldBeFalse();
            "false".ToBool(@default: true).ShouldBeFalse();
            "false".ToBool(@default: false).ShouldBeFalse();
        }
    }
}
