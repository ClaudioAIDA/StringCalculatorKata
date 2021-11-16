using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            string delimiter = "\n";
            if (numbers.StartsWith("//"))
            {
                delimiter = numbers[2].ToString();
                numbers = numbers.Substring(4);
            }

            if (numbers.Contains(",") || numbers.Contains("\n") || numbers.Contains(delimiter))
            {
                IEnumerable<int> parsedNumbers = numbers
                    .Split(new string[] {",", "\n", delimiter}, StringSplitOptions.None)
                    .Select((number) =>
                    {
                        if (number.Equals("")) return 0;
                        return Int32.Parse(number);
                    });
                if (parsedNumbers.Any((number) => number < 0))
                {
                    string negatives = String.Join(" ", parsedNumbers.Where((number) => number < 0));
                    throw new ArgumentException("Negatives not allowed", negatives);
                }

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
            if (numbers.Contains("-")) throw new ArgumentException("Negatives not allowed", numbers);
            return Int32.Parse(numbers);
        }
    }
}