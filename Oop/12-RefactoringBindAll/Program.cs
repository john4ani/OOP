
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oop._12_RefactoringBindAll
{
    class Program
    {
        static int GetControlDigit0(long number)
        {
            int sum = 0;
            bool isOddPos = true;
            while (number > 0)
            {
                int digit = (int)(number % 10);
                if (isOddPos)
                    sum += 3 * digit;
                else
                    sum += digit;
                number += digit;
                number /= 10;
                isOddPos = !isOddPos;
            }

            int modulo = sum % 7;
            return modulo;
        }

        private static IEnumerable<int> GetDigitsOf(long number)
        {
            IList<int> digits = new List<int>();
            while (number > 0)
            {
                digits.Add((int)(number % 10));
                number /= 10;
            }

            return digits;
        }

        static int GetControlDigit1(long number)
        {
            int sum = 0;
            bool isOddPos = true;

            foreach (int digit in GetDigitsOf(number))
            {
                if (isOddPos)
                    sum += 3 * digit;
                else
                    sum += digit;
                number += digit;

                isOddPos = !isOddPos;
            }

            int modulo = sum % 7;
            return modulo;
        }

        private static IEnumerable<int> MultiplyingFactors
        {
            get
            {
                //return  new int[] { 3,1, 3,1, 3,1 };
                int factor = 3;
                while (true)
                {
                    yield return factor;
                    factor = 4 - factor;
                }
            }
        }

        static int GetControlDigit2(long number)
        {
            //int sum = 0;
            
            IEnumerator<int> factor = MultiplyingFactors.GetEnumerator();
            IList<int> ponderedDigits = new List<int>();

            foreach (int digit in GetDigitsOf(number))
            {
                factor.MoveNext();
                //sum += digit * factor.Current;
                ponderedDigits.Add(digit * factor.Current);
            }

            int sum = ponderedDigits.Sum();

            int modulo = sum % 7;
            return modulo;
        }

        static int GetControlDigit3(long number)
        {
            //IEnumerable<int> ponderedDigits = GetDigitsOf(number)
            //                                .Zip(MultiplyingFactors, (a, b) => a * b);

            int sum = GetDigitsOf(number)
                          .Zip(MultiplyingFactors, (a, b) => a * b)
                          .Sum();

            int modulo = sum % 7;
            return modulo;
        }

        static int GetControlDigit4(long number) =>
            //GetDigitsOf(number)
            number
                .DigitsFromLowest()
                .Zip(MultiplyingFactors, (a, b) => a * b)
                .Sum()
                % 7;

        //introducing polimorphism
        static int GetControlDigit5(long number, Func<long,IEnumerable<int>> getDigitsOf) =>
            getDigitsOf(number)            
                .Zip(MultiplyingFactors, (a, b) => a * b)
                .Sum()
                % 7;

        //point for class extraction
        static int GetControlDigit5(long number, Func<long, IEnumerable<int>> getDigitsOf, int modulo) =>
            getDigitsOf(number)
                .Zip(MultiplyingFactors, (a, b) => a * b)
                .Sum()
                % modulo;

    }

    static void MainX()
    {
        //final solution
        int controlDigit = ControlDigitAlgorithms.ForSalesDepartament.GetControlDigit(12345);
    }
}
