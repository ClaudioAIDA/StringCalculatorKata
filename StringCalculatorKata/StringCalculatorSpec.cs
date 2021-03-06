using System;
using Xunit;

namespace StringCalculatorKata
{
    public class StringCalculatorSpec
    {
        [Theory]
        [InlineData(0, "")]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(3, "3")]
        [InlineData(0, "1001")]
        [InlineData(1000, "1000")]
        public void ReturnValueWhenTheStringIsANumber(int expectedValue, string numbers)
        {
            int result = StringCalculator.Add(numbers);

            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData(3,"1,2")]
        [InlineData(3, "2,1")]
        [InlineData(5, "2,3")]
        [InlineData(6,"1,2,3")]
        [InlineData(5, "1001,2,3")]
        public void ReturnValueWhenStringContainsAComma(int expectedValue, string numbers)
        {
            int result = StringCalculator.Add(numbers);

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Return3WhenStringIs1CLRF2()
        {
            int expectedValue = 3;
            int result = StringCalculator.Add("1\n2");

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Return6WhenStringIs1CLRF2Comma3()
        {
            int expectedValue = 6;
            int result = StringCalculator.Add("1\n2,3");

            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData(3, "//;\n1;2")]
        [InlineData(3, "//;\n2;1")]
        [InlineData(6, "//;\n1;2;3")]
        [InlineData(5, "//;\n1002;2;3")]
        [InlineData(6, "//[***]\n1***2***3")]
        [InlineData(6, "//[%%]\n1%%2%%3")]
        [InlineData(6, "//[%X*]\n1%X*2%X*3")]
        [InlineData(6, "//[*][%]\n1*2%3")]
        [InlineData(6, "//[*][&]\n1*2&3")]
        [InlineData(6, "//[*][&&&]\n1*2&&&3")]
        public void ReturnValueWhenStringContainsADelimiter(int expectedValue, string numbers)
        {
            int result = StringCalculator.Add(numbers);

            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData("-2", "-2")]
        [InlineData("-2", "2,-2")]
        [InlineData("-2 -3", "2,-2,-3")]
        public void ThrowsArgumentExceptionWhenStringContainsANegative(string expectedParameter, string numbers)
        {
            Assert.Throws<ArgumentException>(expectedParameter, () => StringCalculator.Add(numbers));
        }

    }
}
