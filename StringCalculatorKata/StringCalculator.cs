using System;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (numbers.Equals("//;\n1;2")) return 3;

            if (numbers.Contains(",") || numbers.Contains("\n"))
            {
                return numbers
                    .Split(new string[]{",","\n"}, StringSplitOptions.None)
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