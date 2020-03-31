


using Oop.Loops;
using System.Collections.Generic;

namespace Oop.Collections
{
    class ProgramX
    {
        static void Main2(string[] args)
        {
            IEnumerable<ProportionalPainter> painters = new ProportionalPainter[10];
            IPainter painter = CompositePainterFactories.CreateGroup(painters);
        }
    }
}
