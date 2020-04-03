using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop._12_RefactoringBindAll
{
    static class Int64Extentions
    {
        public static IEnumerable<int> DigitsFromLowest(this long number)
        {
            do
            {
                yield return (int)(number % 10);
                number /= 10;
            }
            while (number > 0);            
        }
    }
}
