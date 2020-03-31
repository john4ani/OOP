
using System.Collections.Generic;
using System.Linq;

namespace Oop.Loops
{
    class Program4
    {
        private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return painters
                .Where(painter => painter.IsAvailable)
                .WithMinimum2(painter => painter.EstimateCompensation(sqMeters));
        }

        static void Main4(string[] args)
        {
        }
    }
}
