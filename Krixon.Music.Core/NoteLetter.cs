using Krixon.Music.Core.Intervals;

namespace Krixon.Music.Core
{
    public enum NoteLetter
    {
        C,
        D,
        E,
        F,
        G,
        A,
        B
    }

    public static class NoteLetterExtensions
    {
        /// <summary>
        /// Counts the number of semitones from this note letter to another.
        /// For example, given A and C, this would return 3. Given B and C, this would return 1.
        /// </summary>
        /// <param name="a">The first note letter.</param>
        /// <param name="b">The second note letter.</param>
        /// <returns>The number of semitones from note letter a to note letter b.</returns>
        public static int CountSemitonesTo(this NoteLetter a, NoteLetter b)
        {
            var sequence = new[] { 2, 2, 1, 2, 2, 2, 1 };
            var semitones = 0;
            var first = (int) a;
            var last = (int) b;

            for (var i = 0; i < 7; i++)
            {
                var next = (i + first) % 7;
                if (next == last) break;
                semitones += sequence[next];
            }

            return semitones;
        }

        /// <summary>
        /// Returns the note letter which is at a specified offset from this note letter.
        /// For example, given A and 1, this would return B. Given A and 2, this would return C.
        /// The offset wraps, so given A and 7 (or 14, 21, 28 etc), this would return A.
        /// </summary>
        /// <param name="a">The first note letter.</param>
        /// <param name="offset">The offset from the first note letter.</param>
        /// <returns></returns>
        public static NoteLetter Offset(this NoteLetter a, int offset)
        {
            return (NoteLetter) (((int) a + offset) % 7);
        }

        public static NoteLetter Offset(this NoteLetter a, Interval offset)
        {
            return Offset(a, (int) offset.Number);
        }
    }
}
