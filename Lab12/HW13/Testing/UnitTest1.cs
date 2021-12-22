using System;
using WebApplication.Models;
using Xunit;

namespace Testing
{
    public class ExpressionSpecs
    {
        [Theory]
        [InlineData(5 + 5, "5 + 5")]
        [InlineData(5 + 5 + 5, "5 + 5 + 5")]
        [InlineData(5 + 5 * 2, "5 + ( 5 * 2)")]
        [InlineData(-5 + -5, "-5 + -5")]
        [InlineData(-(5 + 5), "-(5 + 5)")]
        [InlineData(1 + 2 / 3, "1 + 2 / 3")]
        [InlineData(25, "5^2")]
        public void PerformsBasicCalculations(double expectedResult, string expression)
        {
            var parser = new ExpressionDynamic();
            Assert.Equal(expectedResult, parser.Execute(expression));
        }

        [Theory]
        [InlineData(Math.PI, "pi")]
        [InlineData(Math.E, "e")]
        public void SupportsMathConstants(double expectedResult, string expression)
        {
            var parser = new ExpressionDynamic();
            Assert.Equal(expectedResult, parser.Execute(expression));
        }

        [Theory]
        [InlineData(2 * 2 / 3.0, "(2 * 2) / 3")]
        [InlineData(2 * 2 * 3, "2 * 2 * 3")]
        public void SupportsMathSymbols(double expectedResult, string expression)
        {
            var parser = new ExpressionDynamic();
            Assert.Equal(expectedResult, parser.Execute(expression));
        }
    }

    public class ExpressionParser
    {
    }
}