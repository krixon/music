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
