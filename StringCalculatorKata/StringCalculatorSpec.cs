using Xunit;

namespace StringCalculatorKata
{
    public class StringCalculatorSpec
    {
        [Fact]
        public void Return0WhenIsAnEmptyString()
        {
            int expectedValue = 0;
            int result = StringCalculator.Add("");
            Assert.Equal(expectedValue, result);
        }
    }
}
