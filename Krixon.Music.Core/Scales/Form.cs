using System.Collections.Generic;
using System.Linq;
using Krixon.Music.Core.Intervals;

namespace Krixon.Music.Core.Scales
{
    /// <summary>
    /// A particular scale form based on its direction.
    /// </summary>
    public sealed class Form
    {
        private readonly Direction? _direction;
        private readonly IDictionary<Number, int> _adjustments;

        /// <param name="adjustments">
        /// A mapping of interval number to adjustment in semitones. Negative semitone values diminish
        /// while positive values augment.
        /// </param>
        /// <param name="direction">
        /// The direction in which the form applies. If not specified, it applies in either direction.
        /// </param>
        private Form(IDictionary<Number, int> adjustments, Direction? direction = null)
        {
            _adjustments = adjustments;
            _direction = direction;
        }

        /// <summary>
        /// Defines a scale form with specified steps augmented when played in either direction.
        /// </summary>
        /// <param name="steps">The augmented steps. 1-based, i.e. the seventh step is 7.</param>
        public static Form Augmented(params int[] steps) => new (StepsToNumbers(steps));

        /// <summary>
        /// Defines a scale form with specified steps augmented when played in a particular direction.
        /// </summary>
        /// <param name="direction">The direction in which the form applies.</param>
        /// <param name="steps">The augmented steps. 1-based, i.e. the seventh step is 7.</param>
        public static Form Augmented(Direction direction, params int[] steps) => new (StepsToNumbers(steps), direction);

        public static Form AugmentedAscending(params int[] steps) => Augmented(Direction.Ascending, steps);

        /// <summary>
        /// Given a set of intervals and a scale direction, returns a new set of intervals which any necessary
        /// augmentations and diminutions applied.
        /// </summary>
        /// <param name="original">The original set of intervals which form a scale.</param>
        /// <param name="direction">The direction in which the scale is being played.</param>
        /// <returns></returns>
        public IEnumerable<Interval> Apply(IEnumerable<Interval> original, Direction direction)
        {
            return _direction == null || direction == _direction ? original.Select(Adjust) : original;
        }

        private Interval Adjust(Interval interval)
        {
            // Look up the adjustment in semitones for this interval.
            // Defaults to 0 causing the interval to be unchanged.
            // Negative values will diminish while positive will augment.
            _adjustments.TryGetValue(interval.Number, out var semitones);

            return interval.Adjust(semitones);
        }

        private static Dictionary<Number, int> StepsToNumbers(IEnumerable<int> steps)
        {
            return steps.ToDictionary(s => (Number) s - 1, _ => 1);
        }
    }
}
