using System.Collections.Generic;
using System.Linq;

namespace Krixon.Music.Core.Intervals
{
    public static class IntervalExtensions
    {
        public static IEnumerable<Interval> Remove(this IEnumerable<Interval> intervals, params int[] steps)
        {
            return intervals.Where(i => !steps.Contains((int) i.Number + 1));
        }

        public static IEnumerable<Interval> Augment(this IEnumerable<Interval> intervals, params int[] steps)
        {
            return intervals.Select(i => steps.Contains((int) i.Number + 1) ? i.Augment() : i);
        }

        public static IEnumerable<Interval> Insert(this IEnumerable<Interval> intervals, Interval interval)
        {
            return intervals.Append(interval).OrderBy(i => i);
        }
    }
}
