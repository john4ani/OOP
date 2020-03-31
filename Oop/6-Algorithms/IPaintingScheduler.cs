using Oop.Collections;
using Oop.Loops;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oop._6_Algorithms
{
    interface IPaintingScheduler<TPainter> where TPainter:IPainter
    {
        IEnumerable<PaintingTask<TPainter>> Schedule(double sqMeters, IEnumerable<TPainter> painters);
    }

    class ProportionalPaintingScheduler : IPaintingScheduler<ProportionalPainter>
    {
        public IEnumerable<PaintingTask<ProportionalPainter>> Schedule(double sqMeters, 
            IEnumerable<ProportionalPainter> painters)
        {
            IEnumerable<Tuple<ProportionalPainter, double>> velocities =
                painters
                .Select(painter => Tuple.Create(painter, sqMeters / painter.EstimateTimeToPaint(sqMeters).TotalHours))
                .ToList();

            double totalVelocity = velocities.Sum(tuple=>tuple.Item2);
            var schedule = velocities
                            .Select(tuple =>
                                new PaintingTask<ProportionalPainter>(
                                    tuple.Item1,
                                    sqMeters * tuple.Item2 / totalVelocity))
                             .ToList();
            return schedule;
        }
    }
}
