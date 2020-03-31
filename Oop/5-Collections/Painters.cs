using Oop.Loops;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oop.Collections
{
    class Painters
    {
        private IEnumerable<IPainter> ContainedPainters { get; }

        public Painters(IEnumerable<IPainter> painters)
        {
            ContainedPainters = painters.ToList();
        }

        public Painters GetAvailable() =>
            new Painters(ContainedPainters.Where(p => p.IsAvailable));

        public IPainter GetCheapestOne(double sqMeters) =>
            ContainedPainters.WithMinimum2(p => p.EstimateCompensation(sqMeters));

        public IPainter GetFastestOne(double sqMeters) =>
            ContainedPainters.WithMinimum2(p => p.EstimateTimeToPaint(sqMeters));
    }
}
