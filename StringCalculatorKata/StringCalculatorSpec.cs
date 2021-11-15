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

        [Fact]
        public void Return3WhenStringIs1Comma2()
        {
            int expectedValue = 3;
            int result = StringCalculator.Add("1,2");

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Return3WhenStringIs2Comma1()
        {
            int expectedValue = 3;
            int result = StringCalculator.Add("2,1");

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Return5WhenStringIs2Comma3()
        {
            int expectedValue = 5;
            int result = StringCalculator.Add("2,3");

            Assert.Equal(expectedValue, result);
        }
    }
}
