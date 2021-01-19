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
        private static readonly Dictionary<string, int> Sharps = new()
        {
            ["#"] = 1,
            ["s"] = 1,
            ["S"] = 1,
            ["♯"] = 1,
            ["𝄪"] = 2,
            ["x"] = 2,
            ["X"] = 2,
        };

        private static readonly Dictionary<string, int> Flats = new()
        {
            ["b"] = -1,
            ["♭"] = -1,
            ["𝄫"] = -2,
        };

        public static Pitch Parse(string str)
        {
            var match = Regex.Match(
                str,
                @"^\s*(?<letter>[a-g])\s*(?<accidentals>[#s♯𝄪xb♭𝄫♮]*)\s*$",
                RegexOptions.IgnoreCase | RegexOptions.Compiled
            );

            if (!match.Success)
            {
                throw new ArgumentException($"Pitch `{str}` is not a valid pitch string.");
            }

            var letter = ParseNoteLetter(match.Groups["letter"].Value);
            var accidentals = ParseAccidentals(match.Groups["accidentals"].Value);

            return new Pitch(letter, accidentals);
        }

        private static NoteLetter ParseNoteLetter(string str)
        {
            return Enum.Parse<NoteLetter>(str.ToUpperInvariant());
        }

        private static int ParseAccidentals(string str)
        {
            if (str.Length == 0) return 0;

            var result = 0;

            // The active accidental dictionary.
            // This is set to either sharps or flats based on the first encountered non-natural symbol.
            // By using the same dictionary, invalid accidental combinations such as C♯♭ are not parsed.
            Dictionary<string, int>? active = null;

            var charEnumerator = StringInfo.GetTextElementEnumerator(str);

            while (charEnumerator.MoveNext())
            {
                var symbol = charEnumerator.GetTextElement();

                // Naturals do not contribute to the final value.
                if (symbol == "♮") continue;

                if (active is null)
                {
                    if (Sharps.ContainsKey(symbol)) active = Sharps;
                    else if (Flats.ContainsKey(symbol)) active = Flats;
                }

                result += active?[symbol] ?? 0;
            }

            return result;
        }
    }
}
