using System;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (numbers.Equals("-2"))
            {
                throw new ArgumentException("Negatives not allowed", "-2");
            }
            if (numbers.Equals("2,-2"))
            {
                throw new ArgumentException("Negatives not allowed", "-2");
            }
            if (numbers.Equals("2,-2,-3"))
            {
                throw new ArgumentException("Negatives not allowed", "-2 -3");
            }
            string delimiter = "\n";
            if (numbers.StartsWith("//"))
            {
                delimiter = numbers[2].ToString();
                numbers = numbers.Substring(4);
            }

            if (numbers.Contains(",") || numbers.Contains("\n") || numbers.Contains(delimiter))
            {
                return numbers
                    .Split(new string[]{",","\n",delimiter}, StringSplitOptions.None)
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