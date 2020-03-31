using System;
using System.Collections.Generic;

namespace Oop.Common
{
    static class EnumerableExtentions
    {
        public static void Do<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            //sequence.ToList().ForEach(action);

            foreach (T obj in sequence)
                action(obj);
        }
    }
}
