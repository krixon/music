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
        [TestCase(-12, "C")]
        [TestCase(-11, "C#")]
        [TestCase(-10, "D")]
        [TestCase(-9, "D#")]
        [TestCase(-8, "E")]
        [TestCase(-7, "F")]
        [TestCase(-6, "F#")]
        [TestCase(-5, "G")]
        [TestCase(-4, "G#")]
        [TestCase(-3, "A")]
        [TestCase(-2, "A#")]
        [TestCase(-1, "B")]
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
        [TestCase(12, "C")]
        public static void Operator_CastFromInt(int pitch, string expected)
        {
            Assert.AreEqual(Pitch.Parse(expected), (Pitch) pitch);
        }

        [Test]
        [TestCase("C", -16, "G#")]
        [TestCase("C", -15, "A")]
        [TestCase("C", -14, "A#")]
        [TestCase("C", -13, "B")]
        [TestCase("C", -12, "C")]
        [TestCase("C", -11, "C#")]
        [TestCase("C", -10, "D")]
        [TestCase("C", -9, "D#")]
        [TestCase("C", -8, "E")]
        [TestCase("C", -7, "F")]
        [TestCase("C", -6, "F#")]
        [TestCase("C", -5, "G")]
        [TestCase("C", -4, "G#")]
        [TestCase("C", -3, "A")]
        [TestCase("C", -2, "A#")]
        [TestCase("C", -1, "B")]
        [TestCase("C", 0, "C")]
        [TestCase("C", 1, "C#")]
        [TestCase("C", 2, "D")]
        [TestCase("C", 3, "D#")]
        [TestCase("C", 4, "E")]
        [TestCase("C", 5, "F")]
        [TestCase("C", 6, "F#")]
        [TestCase("C", 7, "G")]
        [TestCase("C", 8, "G#")]
        [TestCase("C", 9, "A")]
        [TestCase("C", 10, "A#")]
        [TestCase("C", 11, "B")]
        [TestCase("C", 12, "C")]
        [TestCase("C", 13, "C#")]
        [TestCase("C", 14, "D")]
        [TestCase("C", 15, "D#")]
        [TestCase("C", 16, "E")]
        public static void Transpose(string pitch, int semitones, string expected)
        {
            Assert.AreEqual(Pitch.Parse(expected), Pitch.Parse(pitch).Transpose(semitones));
        }
    }
}
