using System.Collections.Generic;
using System.Linq;
using Krixon.Music.Core.Intervals;

namespace Krixon.Music.Core.Scales
{
    public sealed class Scale
    {
        public Note Tonic { get; }
        public IEnumerable<Note> AscendingNotes { get; }
        public IEnumerable<Note> DescendingNotes { get; }

        public int Length => AscendingNotes.Count();

        /// <param name="tonic">The root note of the scale.</param>
        /// <param name="intervals">
        /// A list of intervals from the mode, in semitones, which define the notes in the scale.
        /// </param>
        /// <param name="form">
        /// A scale form which adjusts the intervals when the scale is played in a particular direction.
        /// </param>
        private Scale(Note tonic, IEnumerable<Interval> intervals, Form? form = null)
        {
            Tonic = tonic;

            intervals = intervals as Interval[] ?? intervals.ToArray();

            AscendingNotes = CreateNotesFromIntervals(Tonic, intervals, Direction.Ascending, form);
            DescendingNotes = CreateNotesFromIntervals(Tonic, intervals, Direction.Descending, form);
        }

        public static Scale Major(Note tonic) => Ionian(tonic);
        public static Scale Minor(Note tonic) => Aeolian(tonic);
        public static Scale HarmonicMinor(Note tonic) => new(tonic, Diatonic(6).Augment(7));
        public static Scale MelodicMinor(Note tonic) => new(tonic, Diatonic(6), Form.AugmentedAscending(6, 7));
        public static Scale Ionian(Note tonic) => new(tonic, Diatonic(1));
        public static Scale Dorian(Note tonic) => new(tonic, Diatonic(2));
        public static Scale Phrygian(Note tonic) => new(tonic, Diatonic(3));
        public static Scale Lydian(Note tonic) => new(tonic, Diatonic(4));
        public static Scale Mixolydian(Note tonic) => new(tonic, Diatonic(5));
        public static Scale Aeolian(Note tonic) => new(tonic, Diatonic(6));
        public static Scale Locrian(Note tonic) => new(tonic, Diatonic(7));
        public static Scale MajorPentatonic(Note tonic) => new(tonic, Diatonic(1).Remove(4, 7));
        public static Scale MinorPentatonic(Note tonic) => new(tonic, Diatonic(6).Remove(2, 6));
        public static Scale MajorBlues(Note tonic) => new(tonic, Diatonic(1).Remove(4, 7).Insert(Interval.MinorThird()));
        public static Scale MinorBlues(Note tonic) => new(tonic, Diatonic(6).Remove(2, 6).Insert(Interval.AugmentedFourth()));

        private static IEnumerable<Note> CreateNotesFromIntervals(
            Note tonic, IEnumerable<Interval> intervals, Direction direction, Form? form)
        {
            if (form != null) intervals = form.Apply(intervals, direction);

            var notes = intervals.Select(tonic.Transpose).Prepend(tonic);

            return direction == Direction.Descending ? notes.Reverse() : notes;
        }

        private static IEnumerable<Interval> Diatonic(int mode)
        {
            // T-T-s-T-T-T-s
            var sequence = RotateSequence(new[] {2, 2, 1, 2, 2, 2, 1}, mode);
            var intervals = new Interval[6];
            var semitones = 0;

            for (var i = 0; i < 6; i++)
            {
                semitones += sequence[i];
                intervals[i] = Interval.FromSemitoneCount(semitones, (Number) i + 1);
            }

            return intervals;
        }

        private static int[] RotateSequence(IReadOnlyList<int> sequence, int mode)
        {
            var result = new int[sequence.Count];

            for (var i = 0; i < sequence.Count; i++)
            {
                result[i] = sequence[(i + mode - 1) % sequence.Count];
            }

            return result;
        }
    }
}
