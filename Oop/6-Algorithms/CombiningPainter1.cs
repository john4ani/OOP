using Oop.Collections;
using Oop.Loops;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oop._6_Algorithms
{
    class CombiningPainter : CompositePainter6<ProportionalPainter>
    {
        public CombiningPainter(IEnumerable<ProportionalPainter> painters) : base(painters)
        {
            Reduce = Combine;
        }

        private IPainter Combine(double sqMeters, IEnumerable<ProportionalPainter> painters)
        {
            TimeSpan time = TimeSpan.FromHours(
            1 /
        painters
            .Where(painter => painter.IsAvailable)
            .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours)
            .Sum());

            double cost =
            painters
                .Where(painter => painter.IsAvailable)
                .Select(painter =>
                    painter.EstimateCompensation(sqMeters) /
                    painter.EstimateTimeToPaint(sqMeters).TotalHours *
                    time.TotalHours)
                .Sum();

            return new ProportionalPainter
            {
                TimePerSqrMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                DollarsPerHour = cost / time.TotalHours
            };
        }
    }
}
