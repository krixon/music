using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Krixon.Music.Core.Test
{
    public class PitchTests
    {
        public static IEnumerable<TestCaseData> StringSource()
        {
            var expected = new Dictionary<string, int>
            {
                ["𝄫"] = -2,
                ["♭♭"] = -2,
                ["b"] = -1,
                ["♭"] = -1,
                ["♭♮"] = -1,
                [""] = 0,
                ["♮"] = 0,
                ["♮♮"] = 0,
                ["#"] = 1,
                ["s"] = 1,
                ["S"] = 1,
                ["♯"] = 1,
                ["♯♮"] = 1,
                ["𝄪"] = 2,
                ["x"] = 2,
                ["X"] = 2,
                ["♯♯"] = 2
            };

            foreach (var note in Enum.GetValues<NoteLetter>())
            {
                foreach (var symbol in expected)
                {
                    yield return new TestCaseData($"{note}{symbol.Key}", note, symbol.Value);
                }
            }
        }

        [Test]
        [TestCaseSource(nameof(StringSource))]
        public void Construct_FromString(string str, NoteLetter expectedNoteLetter, int expectedAccidentals)
        {
            Assert.AreEqual(new Pitch(expectedNoteLetter, expectedAccidentals), new Pitch(str));
        }

        [Test]
        [TestCase("CC")]
        [TestCase("Ca")]
        [TestCase("C~")]
        [TestCase("C~")]
        [TestCase("C+")]
        [TestCase("C-")]
        public void Construct_FromString_WithInvalidAccidental(string str)
        {
            Assert.Throws<ArgumentException>(() => new Pitch(str), "contains unknown accidental");
        }
    }
}
