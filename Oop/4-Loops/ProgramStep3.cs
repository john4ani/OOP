
using System.Collections.Generic;
using System.Linq;

namespace Oop.Loops
{
    class Program3
    {
        private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return painters
                .Where(painter => painter.IsAvailable)
                .Aggregate((best, curent) =>
                    best.EstimateCompensation(sqMeters) < curent.EstimateCompensation(sqMeters) ?
                    best : curent);
        }

        static void Main3(string[] args)
        {
        }
    }
}
