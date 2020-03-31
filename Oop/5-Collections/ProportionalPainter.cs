using Oop.Loops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.Collections
{
    public class ProportionalPainter : IPainter
    {
        public TimeSpan TimePerSqrMeter { get; set; }
        public double DollarsPerHour { get; set; }
        public bool IsAvailable => true;

        public double EstimateCompensation(double sqMeters) =>
            EstimateTimeToPaint(sqMeters).TotalHours * DollarsPerHour;

        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            TimeSpan.FromHours(TimePerSqrMeter.TotalHours * sqMeters);
    }
}
