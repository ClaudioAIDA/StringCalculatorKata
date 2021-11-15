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

        [Fact]
        public void Return3WhenStringContainsSemicolorDelimiterAnd1Semicolor2()
        {
            int expectedValue = 3;
            int result = StringCalculator.Add("//;\n1;2");

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Return3WhenStringContainsSemicolorDelimiterAnd2Semicolor1()
        {
            int expectedValue = 3;
            int result = StringCalculator.Add("//;\n2;1");

            Assert.Equal(expectedValue, result);
        }


    }
}
