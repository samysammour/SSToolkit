﻿namespace SSToolkit.Fundamental.Tests.Extensions
{
    using System;
    using Fundamental.Extensions;
    using Shouldly;
    using Xunit;

    public class ExceptionExtensionsTests
    {
        [Fact]
        public void ChecUsingGenerics()
        {
            new InvalidOperationException()
                .IsExpectedException<InvalidOperationException>()
                .ShouldBeTrue();

            new InvalidOperationException()
                .IsExpectedException<ArgumentNullException>()
                .ShouldBeFalse();

            new InvalidOperationException()
                .IsExpectedException<IndexOutOfRangeException, InvalidOperationException>()
                .ShouldBeTrue();

            new InvalidOperationException()
                .IsExpectedException<IndexOutOfRangeException, ArgumentNullException>()
                .ShouldBeFalse();

            new InvalidOperationException("Message")
                .IsExpectedException(x => x.Message == "Message")
                .ShouldBeTrue();
        }
    }
}
