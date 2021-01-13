using System.Collections.Generic;
using System.Linq;
using Krixon.Music.Core.Intervals;

namespace Krixon.Music.Core.Scales
{
    public struct Scale
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
        public static Scale Ionian(Note tonic) => new(tonic, IntervalsFactory.Diatonic(1));
        public static Scale Dorian(Note tonic) => new(tonic, IntervalsFactory.Diatonic(2));
        public static Scale Phrygian(Note tonic) => new(tonic, IntervalsFactory.Diatonic(3));
        public static Scale Lydian(Note tonic)
        {
            var intervals = IntervalsFactory.Diatonic(4);

            // TODO: Handle this within the interval factory by considering the current step of the scale as
            //       well as the number of semitones. In this case, the fourth is augmented (6 semitones), but with
            //       just the semitones we would end up with a diminished fifth.
            intervals[2] = Interval.AugmentedFourth();

            return new(tonic, intervals);
        }

        public static Scale Mixolydian(Note tonic) => new(tonic, IntervalsFactory.Diatonic(5));
        public static Scale Aeolian(Note tonic) => new(tonic, IntervalsFactory.Diatonic(6));
        public static Scale Locrian(Note tonic) => new(tonic, IntervalsFactory.Diatonic(7));

        private static IEnumerable<Note> CreateNotesFromIntervals(Note tonic, IEnumerable<Interval> intervals)
        {
            return intervals.SkipLast(1).Select(tonic.Transpose).Prepend(tonic);
        }

        private static class IntervalsFactory
        {
            public static Interval[] Diatonic(int mode)
            {
                // T-T-s-T-T-T-s
                var sequence = RotateSequence(new[] {2, 2, 1, 2, 2, 2, 1}, mode);
                var intervals = new Interval[7];
                var semitones = 0;

                for (var i = 0; i < sequence.Length; i++)
                {
                    semitones += sequence[i];
                    intervals[i] = Interval.FromSemitoneCount(semitones);
                }

                return intervals;
            }

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
}
