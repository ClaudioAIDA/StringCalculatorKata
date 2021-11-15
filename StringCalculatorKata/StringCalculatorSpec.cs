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
    }
}
