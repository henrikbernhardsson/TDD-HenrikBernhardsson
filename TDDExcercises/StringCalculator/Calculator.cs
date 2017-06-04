using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string input)
        {


            var result = 0;
            var containsNegativeNumbers = false;
            var negativeNumbers = new List<int>();
            var numbers = new List<string>();
            var delimiters = new List<char>() { ',' };

            if (string.IsNullOrEmpty(input))
            {
                return result;
            }
            var rowStrings = input.Split(Environment.NewLine.ToCharArray());

            foreach (var rowString in rowStrings)
            {
                foreach (var delimiter in delimiters)
                {
                    numbers.AddRange(rowString.Split(delimiter));
                }
            }

            foreach (var number in numbers)
            {
                var preResult = 0;
                int.TryParse(number, out preResult);

                if (preResult < 0)
                {
                    containsNegativeNumbers = true;
                    negativeNumbers.Add(preResult);
                }
                else
                {
                    if (preResult < 1001)
                    {
                        result += preResult;
                    }
                        
                }
            }
            if (containsNegativeNumbers)
            {
                var exceptionMessage = "Negative numbers is not allowed. : ";
                foreach (var negativeNumber in negativeNumbers)
                {
                    exceptionMessage += negativeNumber + " ";
                }

                throw new NegativeNumbersNotAllowedException(exceptionMessage);
            }

            return result;
        }
    }
}
