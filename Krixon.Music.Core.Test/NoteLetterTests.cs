using System.Collections.Generic;
using Krixon.Music.Core.Intervals;
using NUnit.Framework;
using static Krixon.Music.Core.Intervals.Interval;

namespace Krixon.Music.Core.Test
{
    [TestFixture]
    public class NoteLetterTests
    {
        [Test]
        [TestCase(NoteLetter.A, NoteLetter.A, 0)]
        [TestCase(NoteLetter.B, NoteLetter.B, 0)]
        [TestCase(NoteLetter.C, NoteLetter.C, 0)]
        [TestCase(NoteLetter.C, NoteLetter.D, 2)]
        [TestCase(NoteLetter.C, NoteLetter.E, 4)]
        [TestCase(NoteLetter.C, NoteLetter.F, 5)]
        [TestCase(NoteLetter.C, NoteLetter.G, 7)]
        [TestCase(NoteLetter.C, NoteLetter.A, 9)]
        [TestCase(NoteLetter.C, NoteLetter.B, 11)]
        [TestCase(NoteLetter.A, NoteLetter.B, 2)]
        [TestCase(NoteLetter.B, NoteLetter.C, 1)]
        [TestCase(NoteLetter.C, NoteLetter.D, 2)]
        [TestCase(NoteLetter.D, NoteLetter.E, 2)]
        [TestCase(NoteLetter.E, NoteLetter.F, 1)]
        [TestCase(NoteLetter.F, NoteLetter.G, 2)]
        [TestCase(NoteLetter.G, NoteLetter.A, 2)]
        public static void CountSemitonesTo(NoteLetter a, NoteLetter b, int expected)
        {
            Assert.AreEqual(expected, a.CountSemitonesTo(b));
        }

        [Test]
        [TestCase(NoteLetter.C, 0, NoteLetter.C)]
        [TestCase(NoteLetter.C, 1, NoteLetter.D)]
        [TestCase(NoteLetter.C, 2, NoteLetter.E)]
        [TestCase(NoteLetter.C, 3, NoteLetter.F)]
        [TestCase(NoteLetter.C, 4, NoteLetter.G)]
        [TestCase(NoteLetter.C, 5, NoteLetter.A)]
        [TestCase(NoteLetter.C, 6, NoteLetter.B)]
        [TestCase(NoteLetter.C, 7, NoteLetter.C)]
        [TestCase(NoteLetter.C, 8, NoteLetter.D)]
        public static void Offset_BySemitones(NoteLetter start, int offset, NoteLetter expected)
        {
            Assert.AreEqual(expected, start.Offset(offset));
        }

        public static IEnumerable<TestCaseData> OffsetByIntervalSource()
        {
            yield return new TestCaseData(NoteLetter.C, Unison(), NoteLetter.C);
            yield return new TestCaseData(NoteLetter.C, MinorSecond(), NoteLetter.D);
            yield return new TestCaseData(NoteLetter.C, MajorSecond(), NoteLetter.D);
            yield return new TestCaseData(NoteLetter.C, MinorThird(), NoteLetter.E);
            yield return new TestCaseData(NoteLetter.C, MajorThird(), NoteLetter.E);
            yield return new TestCaseData(NoteLetter.C, PerfectFourth(), NoteLetter.F);
            yield return new TestCaseData(NoteLetter.C, DiminishedFifth(), NoteLetter.G);
            yield return new TestCaseData(NoteLetter.C, PerfectFifth(), NoteLetter.G);
            yield return new TestCaseData(NoteLetter.C, MinorSixth(), NoteLetter.A);
            yield return new TestCaseData(NoteLetter.C, MajorSixth(), NoteLetter.A);
            yield return new TestCaseData(NoteLetter.C, MinorSeventh(), NoteLetter.B);
            yield return new TestCaseData(NoteLetter.C, MajorSeventh(), NoteLetter.B);
            yield return new TestCaseData(NoteLetter.C, Octave(), NoteLetter.C);
        }

        [Test]
        [TestCaseSource(nameof(OffsetByIntervalSource))]
        public static void Offset_ByInterval(NoteLetter start, Interval interval, NoteLetter expected)
        {
            Assert.AreEqual(expected, start.Offset(interval));
        }
    }
}
