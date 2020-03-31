
using Oop.Loops;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oop.Collections
{
    class Program
    {
        private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return painters
                .Where(painter => painter.IsAvailable)
                .WithMinimum2(painter => painter.EstimateCompensation(sqMeters));
        }

        private static IPainter FindFastesPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return painters
                .Where(painter => painter.IsAvailable)
                .WithMinimum2(painter => painter.EstimateTimeToPaint(sqMeters));
        }

        private static IPainter WorkTogether(double sqMeters, IEnumerable<IPainter> painters)
        {
            TimeSpan time = TimeSpan.FromHours(
                1/
            painters
                .Where(painter => painter.IsAvailable)
                .Select(painter => 1/painter.EstimateTimeToPaint(sqMeters).TotalHours)
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
                TimePerSqrMeter = TimeSpan.FromHours(time.TotalHours/sqMeters),
                DollarsPerHour = cost/time.TotalHours
            };
        }
        
    }
}
