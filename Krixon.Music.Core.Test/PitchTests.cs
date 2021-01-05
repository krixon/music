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
        public void Construct_FromString(string str, NoteLetter expectedNoteLetter, int expectedAccidentals)
        {
            Assert.AreEqual(new Pitch(expectedNoteLetter, expectedAccidentals), new Pitch(str));
        }

        [Test]
        public void Construct_FromString_IgnoresCase()
        {
            Assert.AreEqual(new Pitch("A"), new Pitch("a"));
        }

        [Test]
        public void Construct_FromString_IgnoresWhitespace()
        {
            Assert.AreEqual(new Pitch("A#"), new Pitch(" \tA   #\t\t\t"));
        }

        [Test]
        [TestCase("")]
        [TestCase("H")]
        [TestCase("!")]
        public void Construct_FromString_RejectsInvalidNoteLetter(string str)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Pitch(str));

            Assert.That(exception.Message, Does.Contain("does not contain a valid note letter").IgnoreCase);
        }

        [Test]
        [TestCase("CC")]
        [TestCase("Ca")]
        [TestCase("C~")]
        [TestCase("C~")]
        [TestCase("C+")]
        [TestCase("C-")]
        public void Construct_FromString_RejectsInvalidAccidental(string str)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Pitch(str));

            Assert.That(exception.Message, Does.Contain("contains unknown accidental").IgnoreCase);
        }

        public static IEnumerable<TestCaseData> IntCastSource()
        {
            yield return new TestCaseData("C", 0);
            yield return new TestCaseData("C#", 1);
            yield return new TestCaseData("Db", 1);
            yield return new TestCaseData("D", 2);
            yield return new TestCaseData("D#", 3);
            yield return new TestCaseData("Eb", 3);
            yield return new TestCaseData("E", 4);
            yield return new TestCaseData("E#", 5);
            yield return new TestCaseData("Fb", 4);
            yield return new TestCaseData("F", 5);
            yield return new TestCaseData("F#", 6);
            yield return new TestCaseData("Gb", 6);
            yield return new TestCaseData("G", 7);
            yield return new TestCaseData("G#", 8);
            yield return new TestCaseData("Ab", 8);
            yield return new TestCaseData("A", 9);
            yield return new TestCaseData("A#", 10);
            yield return new TestCaseData("Bb", 10);
            yield return new TestCaseData("B", 11);
            yield return new TestCaseData("B#", 0);
            yield return new TestCaseData("C##", 2);
            yield return new TestCaseData("Dbb", 0);
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
        public void Operator_CastToInt(string pitch, int expected)
        {
            Assert.AreEqual(expected, (int) new Pitch(pitch));
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
        public void Operator_CastFromInt(int pitch, string expected)
        {
            Assert.AreEqual(expected, (Pitch) pitch);
        }
    }
}
