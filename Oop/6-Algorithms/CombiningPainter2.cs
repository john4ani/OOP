using Oop.Collections;
using Oop.Loops;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oop._6_Algorithms
{
    class CombiningPainter2 : CompositePainter6<ProportionalPainter>
    {
        private Func<double, IEnumerable<IPainter>, IEnumerable<Tuple<IPainter, double>>>
            ScheduleWork { get; }

        public CombiningPainter2(IEnumerable<ProportionalPainter> painters,
            Func<double, IEnumerable<IPainter>, IEnumerable<Tuple<IPainter, double>>> scheduleWork) 
            : base(painters)
        {
            Reduce = Combine;
            ScheduleWork = scheduleWork;
        }

        private IPainter Combine(double sqMeters, IEnumerable<ProportionalPainter> painters)
        {
            IEnumerable<IPainter> availablePainters = painters.Where(p => p.IsAvailable);
            IEnumerable<Tuple<IPainter, double>> schedule = ScheduleWork(sqMeters, availablePainters);

            //TimeSpan time = EstimateTime(sqMeters, painters);
            TimeSpan time = schedule.Max(tuple=> tuple.Item1.EstimateTimeToPaint(tuple.Item2));

            double cost = schedule.Sum(tuple => tuple.Item1.EstimateCompensation(tuple.Item2));

            //double cost =
            //painters
            //    .Where(painter => painter.IsAvailable)
            //    .Select(painter =>
            //        painter.EstimateCompensation(sqMeters) /
            //        painter.EstimateTimeToPaint(sqMeters).TotalHours *
            //        time.TotalHours)
            //    .Sum();

            return new ProportionalPainter
            {
                TimePerSqrMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                DollarsPerHour = cost / time.TotalHours
            };
        }

        //Step 1
        //private TimeSpan EstimateTime(double sqMeters, IEnumerable<ProportionalPainter> painters)
        //{
        //    return TimeSpan.FromHours(
        //    1 /
        //painters
        //    .Where(painter => painter.IsAvailable)
        //    .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours)
        //    .Sum());
        //}

        //Step 2
        //public Func<double, IEnumerable<IPainter>,TimeSpan> EstimateTime { get; set; }
    }
}
