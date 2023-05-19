using System;

namespace StringCalculatorkata
{
    // Custom Throw exception error.
    public class NegativeNumberException : ApplicationException {}
    public class StringCalculator
    {
        public static int Add(string input)
        {
            if (input == String.Empty)
            {
                return 0;
            }
            string[] numberList = input.Split(",");
            int total = 0;

            foreach (var number in numberList)
            {
                if (int.Parse(number) < 0)
                {
                    throw new NegativeNumberException();
                }
                if (int.Parse(number) <= 1000)
                {
                    total += int.Parse(number);
                }
            }
            return total;
            //throw new NotImplementedException();
        }

    }
}