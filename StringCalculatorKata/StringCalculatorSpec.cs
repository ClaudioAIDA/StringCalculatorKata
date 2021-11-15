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

        [Fact]
        public void Return1WhenIsTheNumber1AsString()
        {
            int expectedValue = 1;
            int result = StringCalculator.Add("1");
            Assert.Equal(expectedValue, result);
        }
    }
}
