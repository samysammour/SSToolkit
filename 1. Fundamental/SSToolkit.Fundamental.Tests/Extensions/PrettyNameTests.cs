namespace SSToolkit.Fundamental.Tests.Extensions
{
    using SSToolkit.Fundamental;
    using Shouldly;
    using Xunit;

    public class PrettyNameTests
    {
        [Fact]
        public void PrettyName_Test()
        {
            typeof(Stub)
                .PrettyName()
                .ShouldBe("Stub");

            typeof(GenericStub<string>)
                .PrettyName()
                .ShouldBe("GenericStub<String>");
        }

        [Fact]
        public void FullPrettyName_Test()
        {
            typeof(Stub)
                .FullPrettyName()
                .ShouldBe("SSToolkit.Fundamental.Tests.Extensions.Stub");

            typeof(GenericStub<string>)
                .FullPrettyName()
                .ShouldBe("SSToolkit.Fundamental.Tests.Extensions.GenericStub<System.String>");
        }
    }

    public class Stub
    {
    }

    public class GenericStub<T>
    {
    }
}
