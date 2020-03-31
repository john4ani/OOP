using Oop.Collections;
using Oop.Loops;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oop._6_Algorithms
{
    class CombiningPainter3<TPainter> : CompositePainter6<TPainter>
        where TPainter : IPainter
    {
        private Func<double, IEnumerable<TPainter>, IEnumerable<Tuple<TPainter, double>>>
            ScheduleWork { get; }

        public CombiningPainter3(IEnumerable<TPainter> painters,
            Func<double, IEnumerable<TPainter>, IEnumerable<Tuple<TPainter, double>>> scheduleWork) 
            : base(painters)
        {
            Reduce = Combine;
            ScheduleWork = scheduleWork;
        }

        private IPainter Combine(double sqMeters, IEnumerable<TPainter> painters)
        {
            IEnumerable<TPainter> availablePainters = painters.Where(p => p.IsAvailable);
            IEnumerable<Tuple<TPainter, double>> schedule = ScheduleWork(sqMeters, availablePainters);

            TimeSpan time = schedule.Max(tuple=> tuple.Item1.EstimateTimeToPaint(tuple.Item2));

            double cost = schedule.Sum(tuple => tuple.Item1.EstimateCompensation(tuple.Item2));

            return new ProportionalPainter
            {
                TimePerSqrMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                DollarsPerHour = cost / time.TotalHours
            };
        }
    }
}
