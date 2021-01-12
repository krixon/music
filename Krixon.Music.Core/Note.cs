using System;
using System.Text.RegularExpressions;

namespace Krixon.Music.Core
{
    /// <summary>
    /// A single note made up of a pitch at a given octave.
    /// </summary>
    public record Note(Pitch Pitch, int Octave)
    {
        public NoteLetter NoteLetter => Pitch.NoteLetter;
        public int Accidentals => Pitch.Accidentals;

        public static Note Parse(string str)
        {
            var match = Regex.Match(str, @"^(.+?)(\d*)?\s*$");

            if (!match.Success)
            {
                throw new ArgumentException($"Note `{str}` is not a valid note string.");
            }

            return new Note(
                Pitch.Parse(match.Groups[1].Value),
                match.Groups[2].Length > 0 ? int.Parse(match.Groups[2].Value) : 4);
        }

        /// <summary>
        /// Returns a new note by applying an interval to this note.
        /// </summary>
        public Note Transpose(Interval.Interval interval)
        {
            // Transpose with the assumption that we are in a scale and account for enharmonic equivalence.
            // First find the correct note letter based on the interval.
            // Then add the accidentals required to bring the distance to the correct number of semitones.
            // For example, C -> min2 -> Db, not C#.

            var letter = NoteLetter.Offset(interval);
            var accidentals = interval.SemitoneCount % 12 - NoteLetter.CountSemitonesTo(letter) + Accidentals;
            var octave = interval.SemitoneCount / 12 + (NoteLetter > letter ? 1 : 0) + Octave;

            return new Note(new Pitch(letter, accidentals), octave);
        }
    }
}
