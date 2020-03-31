using Oop.Loops;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oop._6_Algorithms
{
    class CompositePainter6<TPainter> : IPainter
        where TPainter : IPainter
    {
        private IEnumerable<TPainter> Painters { get; }

        public bool IsAvailable => Painters.Any(painter => painter.IsAvailable);

        protected Func<double, IEnumerable<TPainter>, IPainter> Reduce { get; set; }

        public CompositePainter6(IEnumerable<TPainter> painters)
        {
            Painters = painters.ToList();            
        }

        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            Reduce(sqMeters, Painters).EstimateTimeToPaint(sqMeters);

        public double EstimateCompensation(double sqMeters) =>
            Reduce(sqMeters, Painters).EstimateCompensation(sqMeters);
    }
}
