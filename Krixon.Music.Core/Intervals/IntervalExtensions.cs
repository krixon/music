using System.Collections.Generic;
using System.Linq;

namespace Krixon.Music.Core.Intervals
{
    public static class IntervalExtensions
    {
        public static IEnumerable<Interval> ExceptSteps(this IEnumerable<Interval> intervals, params int[] steps)
        {
            return intervals.Where(i => !steps.Contains((int) i.Number + 1));
        }
    }
}
