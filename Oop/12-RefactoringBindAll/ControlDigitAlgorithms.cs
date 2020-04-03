using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop._12_RefactoringBindAll
{
    static class ControlDigitAlgorithms
    {
        public static ControlDigitAlgorithm ForSalesDepartament =>
            new ControlDigitAlgorithm(x=>x.DigitsFromLowest(), MultiplyingFactors,9);

        private static IEnumerable<int> MultiplyingFactors
        {
            get
            {
                int factor = 3;
                while (true)
                {
                    yield return factor;
                    factor = 4 - factor;
                }
            }
        }
    }
}
