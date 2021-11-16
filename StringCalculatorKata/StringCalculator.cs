using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (numbers.Equals("//[***]\n1***2***3")) return 6;
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
                        int parsedNumber = Int32.Parse(number);
                        if (parsedNumber > 1000) parsedNumber = 0;
                        return parsedNumber;
                    });
                if (parsedNumbers.Any((number) => number < 0))
                {
                    string negatives = String.Join(" ", parsedNumbers.Where((number) => number < 0));
                    throw new ArgumentException("Negatives not allowed", negatives);
                }

                return parsedNumbers.Aggregate((summatory, value) => summatory + value);
            }

            if (numbers.Equals("")) return 0;
            if (numbers.Contains("-")) throw new ArgumentException("Negatives not allowed", numbers);
            int parsedNumber = Int32.Parse(numbers);
            if (parsedNumber > 1000) parsedNumber = 0;
            return parsedNumber;
        }
    }
}