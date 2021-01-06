using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Krixon.Music.Core
{
    /// <summary>
    /// Pitch is the auditory attribute of sound according to which sounds can be ordered on a scale from low to high.
    /// </summary>
    public record Pitch(NoteLetter NoteLetter, int Accidentals)
    {
        public static Pitch Parse(string str)
        {
            return new Pitch(Parser.NoteLetter(str), Parser.Accidentals(str));
        }

        public static implicit operator int(Pitch pitch)
        {
            return (pitch.NoteLetter switch
            {
                NoteLetter.C => 0,
                NoteLetter.D => 2,
                NoteLetter.E => 4,
                NoteLetter.F => 5,
                NoteLetter.G => 7,
                NoteLetter.A => 9,
                NoteLetter.B => 11,
                _ => throw new ArgumentOutOfRangeException()
            } + pitch.Accidentals) % 12;
        }

        public static implicit operator Pitch(int pitch)
        {
            pitch %= 12;
            if (pitch < 0) pitch += 12;

            return pitch switch
            {
                0 => new Pitch(NoteLetter.C, 0),
                1 => new Pitch(NoteLetter.C, 1),
                2 => new Pitch(NoteLetter.D, 0),
                3 => new Pitch(NoteLetter.D, 1),
                4 => new Pitch(NoteLetter.E, 0),
                5 => new Pitch(NoteLetter.F, 0),
                6 => new Pitch(NoteLetter.F, 1),
                7 => new Pitch(NoteLetter.G, 0),
                8 => new Pitch(NoteLetter.G, 1),
                9 => new Pitch(NoteLetter.A, 0),
                10 => new Pitch(NoteLetter.A, 1),
                11 => new Pitch(NoteLetter.B, 0),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public Pitch Transpose(int semitones)
        {
            return this + semitones;
        }

        private static class Parser
        {
            public static NoteLetter NoteLetter(string str)
            {
                try
                {
                    return Enum.Parse<NoteLetter>(Normalize(str).Substring(0, 1).ToUpperInvariant());
                }
                catch (ArgumentException exception)
                {
                    throw new ArgumentException("Pitch string does not contain a valid note letter.", exception);
                }
            }

            public static int Accidentals(string str)
            {
                str = Normalize(str);

                // A note letter on its own has no accidentals.
                if (str.Length < 2) return 0;

                var result = 0;

                var sharps = new Dictionary<string, int>
                {
                    ["#"] = 1,
                    ["s"] = 1,
                    ["S"] = 1,
                    ["♯"] = 1,
                    ["𝄪"] = 2,
                    ["x"] = 2,
                    ["X"] = 2,
                };

                var flats = new Dictionary<string, int>
                {
                    ["b"] = -1,
                    ["♭"] = -1,
                    ["𝄫"] = -2,
                };

                // The active accidental dictionary.
                // This is set to either sharps or flats based on the first encountered non-natural symbol.
                // By using the same dictionary, invalid accidental combinations such as C♯♭ are not parsed.
                Dictionary<string, int>? active = null;

                var charEnumerator = StringInfo.GetTextElementEnumerator(str.Substring(1));

                while (charEnumerator.MoveNext())
                {
                    var symbol = charEnumerator.GetTextElement();

                    // Naturals do not contribute to the final value.
                    if (symbol == "♮") continue;

                    if (active is null)
                    {
                        if (sharps.ContainsKey(symbol)) active = sharps;
                        else if (flats.ContainsKey(symbol)) active = flats;
                    }

                    if (!(active?.ContainsKey(symbol) ?? false))
                    {
                        throw new ArgumentException(
                            $"Pitch string `{str}` contains unknown accidental `{symbol}`.",
                            nameof(str));
                    }

                    result += active[symbol];
                }

                return result;
            }

            private static string Normalize(string str)
            {
                return Regex.Replace(str, @"\s+", "");
            }
        }
    }
}
