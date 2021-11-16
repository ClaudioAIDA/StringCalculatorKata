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
                if (numbers.Contains("["))
                {
                    do
                    {
                        int delimiterStart = numbers.IndexOf("[") + 1;
                        int delimiterEnd = numbers.IndexOf("]");
                        int delimiterLength = delimiterEnd - delimiterStart;
                        string definedDelimiter = numbers.Substring(delimiterStart, delimiterLength);
                        numbers = numbers.Substring(delimiterEnd + 1).Replace(definedDelimiter, ",");
                    } while (numbers.Contains("["));

                    numbers = numbers.Substring(1);
                }
                else
                {
                    delimiter = numbers[2].ToString();
                    numbers = numbers.Substring(4);
                }
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