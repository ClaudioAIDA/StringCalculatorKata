using System;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (numbers.Equals("")) return 0;
            return Int32.Parse(numbers);
        }
    }
}