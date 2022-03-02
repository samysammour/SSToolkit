namespace SSToolkit.Fundamental.Tests.Extensions
{
    using Fundamental.Extensions;
    using Shouldly;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class AsTests
    {
        [Fact]
        public void AsValidClass_Test()
        {
            var sut = (object)new AsTests();

            sut.As<AsTests>().ShouldNotBe(null);

            sut = null;
            sut.As<AsTests>().ShouldBe(null);
        }

        [Fact]
        public void AsList_Test()
        {
            var list = "as list".AsList();

            list.Count.ShouldBe(1);
            list.First().ShouldBe("as list");
        }

        [Fact]
        public void AsValidString_Test()
        {
            var sut = (object)"test";

            sut.As<string>().ShouldNotBe(null);

            sut = null;
            sut.As<string>().ShouldBe(null);
        }

        [Fact]
        public void AsInvalidInteraface_Test()
        {
            var sut = new AsTests();

            sut.As<ITest>().ShouldBe(null);
        }

#pragma warning disable SA1201 // Elements must appear in the correct order
        public interface ITest
#pragma warning restore SA1201 // Elements must appear in the correct order
        {
        }
    }
}
