using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Krixon.Music.Core.Test
{
    [TestFixture]
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
                foreach (var (symbols, accidentals) in expected)
                {
                    yield return new TestCaseData($"{note}{symbols}", note, accidentals);
                }
            }
        }

        [Test]
        [TestCaseSource(nameof(StringSource))]
        public static void Parse(string str, NoteLetter expectedNoteLetter, int expectedAccidentals)
        {
            Assert.AreEqual(new Pitch(expectedNoteLetter, expectedAccidentals), Pitch.Parse(str));
        }

        [Test]
        public static void Parse_IgnoresCase()
        {
            Assert.AreEqual(Pitch.Parse("A"), Pitch.Parse("a"));
        }

        [Test]
        public static void Parse_IgnoresWhitespace()
        {
            Assert.AreEqual(Pitch.Parse("A#"), Pitch.Parse(" \tA   #\t\t\t"));
        }

        [Test]
        [TestCase("")]
        [TestCase("H")]
        [TestCase("!")]
        public static void Parse_RejectsInvalidNoteLetter(string str)
        {
            var exception = Assert.Throws<ArgumentException>(() => Pitch.Parse(str));

            Assert.That(exception.Message, Does.Contain("does not contain a valid note letter").IgnoreCase);
        }

        [Test]
        [TestCase("CC")]
        [TestCase("Ca")]
        [TestCase("C~")]
        [TestCase("C~")]
        [TestCase("C+")]
        [TestCase("C-")]
        public static void Parse_RejectsInvalidAccidental(string str)
        {
            var exception = Assert.Throws<ArgumentException>(() => Pitch.Parse(str));

            Assert.That(exception.Message, Does.Contain("contains unknown accidental").IgnoreCase);
        }

        [Test]
        [TestCase("C", 0)]
        [TestCase("C#", 1)]
        [TestCase("Db", 1)]
        [TestCase("D", 2)]
        [TestCase("D#", 3)]
        [TestCase("Eb", 3)]
        [TestCase("E", 4)]
        [TestCase("E#", 5)]
        [TestCase("Fb", 4)]
        [TestCase("F", 5)]
        [TestCase("F#", 6)]
        [TestCase("Gb", 6)]
        [TestCase("G", 7)]
        [TestCase("G#", 8)]
        [TestCase("Ab", 8)]
        [TestCase("A", 9)]
        [TestCase("A#", 10)]
        [TestCase("Bb", 10)]
        [TestCase("B", 11)]
        [TestCase("B#", 0)]
        [TestCase("C##", 2)]
        [TestCase("Dbb", 0)]
        public static void Operator_CastToInt(string pitch, int expected)
        {
            Assert.AreEqual(expected, (int) Pitch.Parse(pitch));
        }

        [Test]
        [TestCase(0, "C")]
        [TestCase(1, "C#")]
        [TestCase(2, "D")]
        [TestCase(3, "D#")]
        [TestCase(4, "E")]
        [TestCase(5, "F")]
        [TestCase(6, "F#")]
        [TestCase(7, "G")]
        [TestCase(8, "G#")]
        [TestCase(9, "A")]
        [TestCase(10, "A#")]
        [TestCase(11, "B")]
        public static void Operator_CastFromInt(int pitch, string expected)
        {
            Assert.AreEqual(Pitch.Parse(expected), (Pitch) pitch);
        }
    }
}
