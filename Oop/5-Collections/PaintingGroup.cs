using Oop.Loops;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oop.Collections
{
    class PaintingGroup : IPainter
    {
        private IEnumerable<ProportionalPainter> Painters { get; }

        public bool IsAvailable => Painters.Any(painter => painter.IsAvailable);

        public PaintingGroup(IEnumerable<ProportionalPainter> painters)
        {
            Painters = painters.ToList();
        }

        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            Reduce(sqMeters).EstimateTimeToPaint(sqMeters);

        public double EstimateCompensation(double sqMeters) =>
            Reduce(sqMeters).EstimateCompensation(sqMeters);

        private IPainter Reduce(double sqMeters)
        {
            TimeSpan time = TimeSpan.FromHours(
                1 /
            Painters
                .Where(painter => painter.IsAvailable)
                .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours)
                .Sum());

            double cost =
            this.Painters
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
