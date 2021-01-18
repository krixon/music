using System.Collections.Generic;
using System.Linq;
using Krixon.Music.Core.Intervals;

namespace Krixon.Music.Core.Scales
{
    /// <summary>
    /// Augments or diminishes a scale's intervals based on the direction in which it is played.
    /// </summary>
    public sealed class Form
    {
        private readonly Direction _direction;
        private readonly IDictionary<Number, int> _adjustments;

        /// <param name="direction">The direction in which the form applies.</param>
        /// <param name="adjustments">
        /// A mapping of interval number to adjustment in semitones. Negative semitone values diminish
        /// while positive values augment.
        /// </param>
        private Form(Direction direction, IDictionary<Number, int> adjustments)
        {
            _adjustments = adjustments;
            _direction = direction;
        }

        /// <summary>
        /// Create a scale form which augments specified steps when played ascending.
        /// </summary>
        /// <param name="steps">The steps of the scale to augment. 1-based, i.e. the seventh step is 7.</param>
        /// <returns></returns>
        public static Form AugmentedAscending(params int[] steps) => Augmented(Direction.Ascending, steps);

        /// <summary>
        /// Given a set of intervals and a scale direction, produce a new set of intervals which any necessary
        /// augmentations and diminutions applied.
        /// </summary>
        /// <param name="original">The original set of intervals which form a scale.</param>
        /// <param name="direction">The direction in which the scale is being played.</param>
        /// <returns></returns>
        public IEnumerable<Interval> Apply(IEnumerable<Interval> original, Direction direction)
        {
            return direction == _direction ? original.Select(Adjust) : original;
        }

        private Interval Adjust(Interval interval)
        {
            // Look up the adjustment in semitones for this interval.
            // Defaults to 0 causing the interval to be unchanged.
            _adjustments.TryGetValue(interval.Number, out var semitones);

            return interval.Adjust(semitones);
        }

        /// <summary>
        /// Defines a scale form with specified steps augmented when played in a particular direction.
        /// </summary>
        /// <param name="direction">The direction in which the form applies.</param>
        /// <param name="steps">The augmented steps. 1-based, i.e. the seventh step is 7.</param>
        private static Form Augmented(Direction direction, params int[] steps)
        {
            return new(direction, DefineAdjustments(steps, 1));
        }

        private static Dictionary<Number, int> DefineAdjustments(IEnumerable<int> steps, int semitones)
        {
            return steps.ToDictionary(s => (Number) s - 1, _ => semitones);
        }
    }
}
