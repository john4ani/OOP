using Oop.Collections;
using Oop.Loops;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oop._6_Algorithms
{
    class CombiningPainter4<TPainter> : CompositePainter6<TPainter>
        where TPainter : IPainter
    {
        private IPaintingScheduler<TPainter> ScheduleWork { get; }

        public CombiningPainter4(IEnumerable<TPainter> painters, IPaintingScheduler<TPainter> scheduleWork) 
            : base(painters)
        {
            Reduce = Combine;
            ScheduleWork = scheduleWork;
        }

        private IPainter Combine(double sqMeters, IEnumerable<TPainter> painters)
        {
            IEnumerable<TPainter> availablePainters = painters.Where(p => p.IsAvailable);
            IEnumerable<PaintingTask<TPainter>> schedule = ScheduleWork.Schedule(sqMeters, availablePainters);

            TimeSpan time = schedule.Max(task=> task.Painter.EstimateTimeToPaint(task.SqMeters));

            double cost = schedule.Sum(task => task.Painter.EstimateCompensation(task.SqMeters));

            return new ProportionalPainter
            {
                TimePerSqrMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                DollarsPerHour = cost / time.TotalHours
            };
        }
    }
}
