using Oop.Loops;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oop.Collections
{
    class CompositePainter<TPainter> : IPainter
        where TPainter : IPainter
    {
        private IEnumerable<TPainter> Painters { get; }

        public bool IsAvailable => Painters.Any(painter => painter.IsAvailable);

        private Func<double, IEnumerable<TPainter>, IPainter> Reduce { get; }

        public CompositePainter(IEnumerable<TPainter> painters,
                    Func<double, IEnumerable<TPainter>, IPainter> reduce)
        {
            Painters = painters.ToList();
            Reduce = reduce;
        }

        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            Reduce(sqMeters, Painters).EstimateTimeToPaint(sqMeters);

        public double EstimateCompensation(double sqMeters) =>
            Reduce(sqMeters, Painters).EstimateCompensation(sqMeters);
    }
}
