using Oop.Loops;
using System;

namespace Oop._6_Algorithms
{
    class PaintingTask<TPainter> where TPainter : IPainter
    {
        public PaintingTask(TPainter painter, double sqMeters)
        {
            Painter = painter;
            SqMeters = sqMeters;
        }

        public TPainter Painter { get; }
        public double SqMeters { get; }
    }
}
