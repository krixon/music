using System;
using System.Collections.Generic;
using System.Linq;
using Krixon.Music.Core.Intervals;
using NUnit.Framework;
using static Krixon.Music.Core.Intervals.Interval;

namespace Krixon.Music.Core.Test.Intervals
{
    [TestFixture]
    public class IntervalTests
    {
        [Test]
        [TestCase(0, null, Quality.Perfect, Number.Unison)]
        [TestCase(0, Number.Second, Quality.Diminished, Number.Second)]
        [TestCase(1, null, Quality.Minor, Number.Second)]
        [TestCase(1, Number.Unison, Quality.Augmented, Number.Unison)]
        [TestCase(2, null, Quality.Major, Number.Second)]
        [TestCase(2, Number.Third, Quality.Diminished, Number.Third)]
        [TestCase(3, null, Quality.Minor, Number.Third)]
        [TestCase(3, Number.Second, Quality.Augmented, Number.Second)]
        [TestCase(4, null, Quality.Major, Number.Third)]
        [TestCase(4, Number.Fourth, Quality.Diminished, Number.Fourth)]
        [TestCase(5, null, Quality.Perfect, Number.Fourth)]
        [TestCase(5, Number.Third, Quality.Augmented, Number.Third)]
        [TestCase(6, null, Quality.Diminished, Number.Fifth)]
        [TestCase(6, Number.Fourth, Quality.Augmented, Number.Fourth)]
        [TestCase(7, null, Quality.Perfect, Number.Fifth)]
        [TestCase(7, Number.Sixth, Quality.Diminished, Number.Sixth)]
        [TestCase(8, null, Quality.Minor, Number.Sixth)]
        [TestCase(8, Number.Fifth, Quality.Augmented, Number.Fifth)]
        [TestCase(9, null, Quality.Major, Number.Sixth)]
        [TestCase(9, Number.Seventh, Quality.Diminished, Number.Seventh)]
        [TestCase(10, null, Quality.Minor, Number.Seventh)]
        [TestCase(10, Number.Sixth, Quality.Augmented, Number.Sixth)]
        [TestCase(11, null, Quality.Major, Number.Seventh)]
        [TestCase(11, Number.Octave, Quality.Diminished, Number.Octave)]
        [TestCase(12, null, Quality.Perfect, Number.Octave)]
        [TestCase(12, Number.Seventh, Quality.Augmented, Number.Seventh)]
        [TestCase(13, null, Quality.Minor, Number.Second)]
        [TestCase(14, null, Quality.Major, Number.Second)]
        [TestCase(15, null, Quality.Minor, Number.Third)]
        [TestCase(16, null, Quality.Major, Number.Third)]
        [TestCase(17, null, Quality.Perfect, Number.Fourth)]
        [TestCase(18, null, Quality.Diminished, Number.Fifth)]
        [TestCase(19, null, Quality.Perfect, Number.Fifth)]
        [TestCase(20, null, Quality.Minor, Number.Sixth)]
        [TestCase(21, null, Quality.Major, Number.Sixth)]
        [TestCase(22, null, Quality.Minor, Number.Seventh)]
        [TestCase(23, null, Quality.Major, Number.Seventh)]
        [TestCase(24, null, Quality.Perfect, Number.Octave)]
        [TestCase(36, null, Quality.Perfect, Number.Octave)]
        [TestCase(48, null, Quality.Perfect, Number.Octave)]
        public static void FromSemitoneCount(int semitones, Number? number, Quality expectedQuality, Number expectedNumber)
        {
            var interval = Interval.FromSemitoneCount(semitones, number);

            Assert.AreEqual(expectedQuality, interval.Quality);
            Assert.AreEqual(expectedNumber, interval.Number);
        }

        [Test]
        public static void FromSemitoneCount_WithIncompatibleHint()
        {
            var exception = Assert.Throws<InvalidHintException>(() => Interval.FromSemitoneCount(1, Number.Fifth));

            Assert.That(exception.Message, Does.Contain("incompatible with semitone count").IgnoreCase);
        }

        public static IEnumerable<TestCaseData> AugmentationSource()
        {
            yield return new TestCaseData(Unison(), AugmentedUnison());
            yield return new TestCaseData(DiminishedSecond(), MinorSecond());
            yield return new TestCaseData(MinorSecond(), MajorSecond());
            yield return new TestCaseData(MajorSecond(), AugmentedSecond());
            yield return new TestCaseData(DiminishedThird(), MinorThird());
            yield return new TestCaseData(MinorThird(), MajorThird());
            yield return new TestCaseData(MajorThird(), AugmentedThird());
            yield return new TestCaseData(DiminishedFourth(), PerfectFourth());
            yield return new TestCaseData(PerfectFourth(), AugmentedFourth());
            yield return new TestCaseData(DiminishedFifth(), PerfectFifth());
            yield return new TestCaseData(PerfectFifth(), AugmentedFifth());
            yield return new TestCaseData(DiminishedSixth(), MinorSixth());
            yield return new TestCaseData(MinorSixth(), MajorSixth());
            yield return new TestCaseData(DiminishedSeventh(), MinorSeventh());
            yield return new TestCaseData(MinorSeventh(), MajorSeventh());
            yield return new TestCaseData(MajorSeventh(), AugmentedSeventh());
            yield return new TestCaseData(DiminishedOctave(), Octave());
        }

        [Test]
        [TestCaseSource(nameof(AugmentationSource))]
        public static void Augment(Interval start, Interval expected)
        {
            Assert.AreEqual(expected, start.Augment());
        }

        [Test]
        public static void Augment_WithAugmented()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => AugmentedUnison().Augment());

            Assert.That(exception.Message, Does.Contain("cannot be augmented").IgnoreCase);
        }

        public static IEnumerable<TestCaseData> DiminutionSource()
        {
            return AugmentationSource().Select(data => new TestCaseData(data.Arguments[1], data.Arguments[0]));
        }

        [Test]
        [TestCaseSource(nameof(DiminutionSource))]
        public static void Diminish(Interval start, Interval expected)
        {
            Assert.AreEqual(expected, start.Diminish());
        }

        [Test]
        public static void Augment_WithDiminished()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => DiminishedSecond().Diminish());

            Assert.That(exception.Message, Does.Contain("cannot be diminished").IgnoreCase);
        }
    }
}
