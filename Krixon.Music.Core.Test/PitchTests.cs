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
    }
}
