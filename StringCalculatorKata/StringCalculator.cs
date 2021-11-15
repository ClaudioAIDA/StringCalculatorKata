using System;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (numbers.Contains(","))
            {
                return numbers
                    .Split(",")
                    .Select((number) =>
                        {
                            if (number.Equals("")) return 0;
                            return Int32.Parse(number);
                        })
                    .Aggregate((summatory, value) => summatory + value);
            }

            if (numbers.Equals("")) return 0;
            return Int32.Parse(numbers);
        }
    }
}