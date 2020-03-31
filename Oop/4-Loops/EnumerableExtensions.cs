using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.Loops
{
    public static class EnumerableExtensions
    {
        public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
            where T : class
            where TKey : IComparable<TKey> =>
            sequence.Aggregate((T)null, (best, curent) =>
                 best == null || criterion(curent).CompareTo(criterion(best)) < 0 ? curent : best);

        //more eficient
        public static T WithMinimum2<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
            where T : class
            where TKey : IComparable<TKey> =>
            sequence
                .Select(obj => Tuple.Create(obj, criterion(obj)))
                .Aggregate((Tuple<T, TKey>)null,
                    (best, curent) => best == null || curent.Item2.CompareTo(best.Item2) < 0 ? curent : best)
                .Item1;
    }
}
