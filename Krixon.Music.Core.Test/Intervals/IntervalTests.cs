using Krixon.Music.Core.Intervals;
using NUnit.Framework;

namespace Krixon.Music.Core.Test.Intervals
{
    [TestFixture]
    public class IntervalTests
    {
        [Test]
        [TestCase(0, Quality.Perfect, Number.Unison)]
        [TestCase(1, Quality.Minor, Number.Second)]
        [TestCase(2, Quality.Major, Number.Second)]
        [TestCase(3, Quality.Minor, Number.Third)]
        [TestCase(4, Quality.Major, Number.Third)]
        [TestCase(5, Quality.Perfect, Number.Fourth)]
        [TestCase(6, Quality.Diminished, Number.Fifth)]
        [TestCase(7, Quality.Perfect, Number.Fifth)]
        [TestCase(8, Quality.Minor, Number.Sixth)]
        [TestCase(9, Quality.Major, Number.Sixth)]
        [TestCase(10, Quality.Minor, Number.Seventh)]
        [TestCase(11, Quality.Major, Number.Seventh)]
        [TestCase(12, Quality.Perfect, Number.Octave)]
        [TestCase(13, Quality.Minor, Number.Second)]
        [TestCase(14, Quality.Major, Number.Second)]
        [TestCase(15, Quality.Minor, Number.Third)]
        [TestCase(16, Quality.Major, Number.Third)]
        [TestCase(17, Quality.Perfect, Number.Fourth)]
        [TestCase(18, Quality.Diminished, Number.Fifth)]
        [TestCase(19, Quality.Perfect, Number.Fifth)]
        [TestCase(20, Quality.Minor, Number.Sixth)]
        [TestCase(21, Quality.Major, Number.Sixth)]
        [TestCase(22, Quality.Minor, Number.Seventh)]
        [TestCase(23, Quality.Major, Number.Seventh)]
        [TestCase(24, Quality.Perfect, Number.Octave)]
        [TestCase(36, Quality.Perfect, Number.Octave)]
        [TestCase(48, Quality.Perfect, Number.Octave)]
        public static void FromSemitoneCount(int semitones, Quality expectedQuality, Number expectedNumber)
        {
            var interval = Interval.FromSemitoneCount(semitones);

            Assert.AreEqual(expectedQuality, interval.Quality);
            Assert.AreEqual(expectedNumber, interval.Number);
        }
    }
}
