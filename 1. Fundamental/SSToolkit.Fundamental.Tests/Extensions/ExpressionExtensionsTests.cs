namespace SSToolkit.Fundamental.Tests.Extensions
{
    using System;
    using System.Linq.Expressions;
    using Fundamental.Extensions;
    using Shouldly;
    using Xunit;

    public class ExpressionExtensionsTests
    {
        [Fact]
        public void GetPropertyName_Tests()
        {
            Expression<Func<ExpressionStub, int>> memberExpresssion = t => t.Id;

            memberExpresssion.Body.GetPropertyName<int>().ShouldBe("Id");
        }

        [Fact]
        public void ToExpressionString_Tests()
        {
            // arrange
            Expression<Func<string, bool>> boolExpression = t => t == "item1";
            Expression<Func<string, object>> objectExpression = t => (object)t == "item1";

            // act
            var boolExpressionString = boolExpression.ToExpressionString();
            var objectExpressionString = objectExpression.ToExpressionString();

            // assert
            Assert.Equal("(t == \"item1\")", boolExpressionString);
            Assert.Equal("Convert((Convert(t, Object) == \"item1\"), Object)", objectExpressionString);
        }

        [Fact]
        public void And_Tests()
        {
            // arrange6
            Expression<Func<string, bool>> firstExpression = t => t == "item1";
            Expression<Func<string, bool>> secondExpression = t => t == "item2";

            // act
            var newExpression = firstExpression.And(secondExpression);
            var func = newExpression.Compile();
            var result = func("item1");

            // assert
            Assert.False(result);
        }

        [Fact]
        public void Or_Tests()
        {
            // arrange6
            Expression<Func<string, bool>> firstExpression = t => t == "item1";
            Expression<Func<string, bool>> secondExpression = t => t == "item2";

            // act
            var newExpression = firstExpression.Or(secondExpression);
            var func = newExpression.Compile();
            var result = func("item1");

            // assert
            Assert.True(result);
        }

        [Fact]
        public void Not_Tests()
        {
            // arrange6
            Expression<Func<string, bool>> expression = t => t == "item1";

            // act
            var newExpression = expression.Not();
            var func = newExpression.Compile();
            var result1 = func("item1");
            var result2 = func("item2");

            // assert
            Assert.False(result1);
            Assert.True(result2);
        }
    }

    public class ExpressionStub
    {
        public int Id { get; set; }
    }
}
