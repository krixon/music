using System.Collections.Generic;
using System.Linq;
using Krixon.Music.Core.Intervals;

namespace Krixon.Music.Core.Scales
{
    public readonly struct Scale
    {
        public IEnumerable<Note> Notes { get; }
        public Note Tonic { get; }

        public int Length => Notes.Count();

        /// <param name="tonic">The root note of the scale.</param>
        /// <param name="intervals">A list of intervals from the mode, in semitones, which define the notes in the scale.</param>
        private Scale(Note tonic, IEnumerable<Interval> intervals)
        {
            Tonic = tonic;
            Notes = CreateNotesFromIntervals(Tonic, intervals);
        }

        public static Scale Major(Note tonic) => Ionian(tonic);
        public static Scale Minor(Note tonic) => Aeolian(tonic);
        public static Scale HarmonicMinor(Note tonic) => new(tonic, Diatonic(6, Augment(7)));
        public static Scale Ionian(Note tonic) => new(tonic, Diatonic(1));
        public static Scale Dorian(Note tonic) => new(tonic, Diatonic(2));
        public static Scale Phrygian(Note tonic) => new(tonic, Diatonic(3));
        public static Scale Lydian(Note tonic) => new(tonic, Diatonic(4));
        public static Scale Mixolydian(Note tonic) => new(tonic, Diatonic(5));
        public static Scale Aeolian(Note tonic) => new(tonic, Diatonic(6));
        public static Scale Locrian(Note tonic) => new(tonic, Diatonic(7));

        private static IEnumerable<Note> CreateNotesFromIntervals(Note tonic, IEnumerable<Interval> intervals)
        {
            return intervals.Select(tonic.Transpose).Prepend(tonic);
        }

        public static Interval[] Diatonic(int mode, IDictionary<int, int>? adjustments = null)
        {
            // T-T-s-T-T-T-s
            var sequence = RotateSequence(new[] {2, 2, 1, 2, 2, 2, 1}, mode);
            var intervals = new Interval[6];
            var semitones = 0;

            for (var i = 0; i < 6; i++)
            {
                // If step n is to be augmented or diminished, the interval n-1 must be adjusted accordingly.
                var adjustment = adjustments?.ContainsKey(i + 2) ?? false ? adjustments[i + 2] : 0;

                semitones += sequence[i];
                intervals[i] = Interval.FromSemitoneCount(semitones + adjustment, (Number) i + 1);
            }

            return intervals;
        }

        /// <summary>
        /// Creates a adjustments dictionary which augments specific steps of the scale by a semitone.
        /// </summary>
        /// <param name="steps">The 1-based step in the scale to augment.</param>
        public static Dictionary<int, int> Augment(params int[] steps) => steps.ToDictionary(s => s, _ => 1);

        private static int[] RotateSequence(int[] sequence, int mode)
        {
            var result = new int[sequence.Length];

            for (var i = 0; i < sequence.Length; i++)
            {
                result[i] = sequence[(i + mode - 1) % sequence.Length];
            }

            return result;
        }
    }
}
