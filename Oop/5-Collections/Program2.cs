
using Oop.Loops;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oop.Collections
{
    class Program2
    {
        private static IPainter FindCheapestPainter(double sqMeters, Painters painters) =>        
            painters.GetAvailable().GetCheapestOne(sqMeters);


        private static IPainter FindFastesPainter(double sqMeters, Painters painters) =>
            painters.GetAvailable().GetFastestOne(sqMeters);        

        static void Main2(string[] args)
        {
        }
    }
}
