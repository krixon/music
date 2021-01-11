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

        public Note Transpose(int semitones)
        {
            return new Note(Pitch.Transpose(semitones), semitones / 12 + Octave);
        }
    }
}
