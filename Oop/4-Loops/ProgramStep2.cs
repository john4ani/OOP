
using System.Collections.Generic;
using System.Linq;

namespace Oop.Loops
{
    class Program2
    {
        private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return painters
                .Where(painter => painter.IsAvailable)
                .OrderBy(painter => painter.EstimateCompensation(sqMeters))
                .FirstOrDefault();
        }

        static void Main2(string[] args)
        {
        }
    }
}
