using System.Collections.Generic;
using NUnit.Framework;
using static Krixon.Music.Core.Interval.Interval;

namespace Krixon.Music.Core.Test
{
    [TestFixture]
    public class NoteTests
    {
        [Test]
        [TestCase("C0", "C", 0)]
        [TestCase("C1", "C", 1)]
        [TestCase("C2", "C", 2)]
        [TestCase("C3", "C", 3)]
        [TestCase("C4", "C", 4)]
        [TestCase("C5", "C", 5)]
        [TestCase("C6", "C", 6)]
        [TestCase("C7", "C", 7)]
        [TestCase("C8", "C", 8)]
        [TestCase("C9", "C", 9)]
        [TestCase("A", "A", 4)]
        [TestCase("B", "B", 4)]
        [TestCase("C", "C", 4)]
        [TestCase("D", "D", 4)]
        [TestCase("E", "E", 4)]
        [TestCase("F", "F", 4)]
        [TestCase("G", "G", 4)]
        [TestCase("C#", "C#", 4)]
        [TestCase("C##", "C##", 4)]
        [TestCase("C##2", "C##", 2)]
        public static void Parse(string str, string expectedPitch, int expectedOctave)
        {
            Assert.AreEqual(new Note(Pitch.Parse(expectedPitch), expectedOctave), Note.Parse(str));
        }

        public static IEnumerable<TestCaseData> TransposeSource()
        {
            yield return new TestCaseData("Cb3", Unison(), "Cb3");
            yield return new TestCaseData("C3", Unison(), "C3");
            yield return new TestCaseData("C#3", Unison(), "C#3");
            yield return new TestCaseData("Db3", Unison(), "Db3");
            yield return new TestCaseData("D3", Unison(), "D3");
            yield return new TestCaseData("D#3", Unison(), "D#3");
            yield return new TestCaseData("Eb3", Unison(), "Eb3");
            yield return new TestCaseData("E3", Unison(), "E3");
            yield return new TestCaseData("E#3", Unison(), "E#3");
            yield return new TestCaseData("Fb3", Unison(), "Fb3");
            yield return new TestCaseData("F3", Unison(), "F3");
            yield return new TestCaseData("F#3", Unison(), "F#3");
            yield return new TestCaseData("Gb3", Unison(), "Gb3");
            yield return new TestCaseData("G3", Unison(), "G3");
            yield return new TestCaseData("G#3", Unison(), "G#3");
            yield return new TestCaseData("Ab3", Unison(), "Ab3");
            yield return new TestCaseData("A3", Unison(), "A3");
            yield return new TestCaseData("A#3", Unison(), "A#3");
            yield return new TestCaseData("Bb3", Unison(), "Bb3");
            yield return new TestCaseData("B3", Unison(), "B3");
            yield return new TestCaseData("B#3", Unison(), "B#3");

            yield return new TestCaseData("Cb3", MinorSecond(), "Dbb3");
            yield return new TestCaseData("C3", MinorSecond(), "Db3");
            yield return new TestCaseData("C#3", MinorSecond(), "D3");
            yield return new TestCaseData("Db3", MinorSecond(), "Ebb3");
            yield return new TestCaseData("D3", MinorSecond(), "Eb3");
            yield return new TestCaseData("D#3", MinorSecond(), "E3");
            yield return new TestCaseData("Eb3", MinorSecond(), "Fb3");
            yield return new TestCaseData("E3", MinorSecond(), "F3");
            yield return new TestCaseData("E#3", MinorSecond(), "F#3");
            yield return new TestCaseData("Fb3", MinorSecond(), "Gbb3");
            yield return new TestCaseData("F3", MinorSecond(), "Gb3");
            yield return new TestCaseData("F#3", MinorSecond(), "G3");
            yield return new TestCaseData("Gb3", MinorSecond(), "Abb3");
            yield return new TestCaseData("G3", MinorSecond(), "Ab3");
            yield return new TestCaseData("G#3", MinorSecond(), "A3");
            yield return new TestCaseData("Ab3", MinorSecond(), "Bbb3");
            yield return new TestCaseData("A3", MinorSecond(), "Bb3");
            yield return new TestCaseData("A#3", MinorSecond(), "B3");
            yield return new TestCaseData("Bb3", MinorSecond(), "Cb4");
            yield return new TestCaseData("B3", MinorSecond(), "C4");
            yield return new TestCaseData("B#3", MinorSecond(), "C#4");

            yield return new TestCaseData("Cb3", MajorSecond(), "Db3");
            yield return new TestCaseData("C3", MajorSecond(), "D3");
            yield return new TestCaseData("C#3", MajorSecond(), "D#3");
            yield return new TestCaseData("Db3", MajorSecond(), "Eb3");
            yield return new TestCaseData("D3", MajorSecond(), "E3");
            yield return new TestCaseData("D#3", MajorSecond(), "E#3");
            yield return new TestCaseData("Eb3", MajorSecond(), "F3");
            yield return new TestCaseData("E3", MajorSecond(), "F#3");
            yield return new TestCaseData("E#3", MajorSecond(), "F##3");
            yield return new TestCaseData("Fb3", MajorSecond(), "Gb3");
            yield return new TestCaseData("F3", MajorSecond(), "G3");
            yield return new TestCaseData("F#3", MajorSecond(), "G#3");
            yield return new TestCaseData("Gb3", MajorSecond(), "Ab3");
            yield return new TestCaseData("G3", MajorSecond(), "A3");
            yield return new TestCaseData("G#3", MajorSecond(), "A#3");
            yield return new TestCaseData("Ab3", MajorSecond(), "Bb3");
            yield return new TestCaseData("A3", MajorSecond(), "B3");
            yield return new TestCaseData("A#3", MajorSecond(), "B#3");
            yield return new TestCaseData("Bb3", MajorSecond(), "C4");
            yield return new TestCaseData("B3", MajorSecond(), "C#4");
            yield return new TestCaseData("B#3", MajorSecond(), "C##4");

            yield return new TestCaseData("Cb3", MinorThird(), "Ebb3");
            yield return new TestCaseData("C3", MinorThird(), "Eb3");
            yield return new TestCaseData("C#3", MinorThird(), "E3");
            yield return new TestCaseData("Db3", MinorThird(), "Fb3");
            yield return new TestCaseData("D3", MinorThird(), "F3");
            yield return new TestCaseData("D#3", MinorThird(), "F#3");
            yield return new TestCaseData("Eb3", MinorThird(), "Gb3");
            yield return new TestCaseData("E3", MinorThird(), "G3");
            yield return new TestCaseData("E#3", MinorThird(), "G#3");
            yield return new TestCaseData("Fb3", MinorThird(), "Abb3");
            yield return new TestCaseData("F3", MinorThird(), "Ab3");
            yield return new TestCaseData("F#3", MinorThird(), "A3");
            yield return new TestCaseData("Gb3", MinorThird(), "Bbb3");
            yield return new TestCaseData("G3", MinorThird(), "Bb3");
            yield return new TestCaseData("G#3", MinorThird(), "B3");
            yield return new TestCaseData("Ab3", MinorThird(), "Cb4");
            yield return new TestCaseData("A3", MinorThird(), "C4");
            yield return new TestCaseData("A#3", MinorThird(), "C#4");
            yield return new TestCaseData("Bb3", MinorThird(), "Db4");
            yield return new TestCaseData("B3", MinorThird(), "D4");
            yield return new TestCaseData("B#3", MinorThird(), "D#4");

            yield return new TestCaseData("Cb3", MajorThird(), "Eb3");
            yield return new TestCaseData("C3", MajorThird(), "E3");
            yield return new TestCaseData("C#3", MajorThird(), "E#3");
            yield return new TestCaseData("Db3", MajorThird(), "F3");
            yield return new TestCaseData("D3", MajorThird(), "F#3");
            yield return new TestCaseData("D#3", MajorThird(), "F##3");
            yield return new TestCaseData("Eb3", MajorThird(), "G3");
            yield return new TestCaseData("E3", MajorThird(), "G#3");
            yield return new TestCaseData("E#3", MajorThird(), "G##3");
            yield return new TestCaseData("Fb3", MajorThird(), "Ab3");
            yield return new TestCaseData("F3", MajorThird(), "A3");
            yield return new TestCaseData("F#3", MajorThird(), "A#3");
            yield return new TestCaseData("Gb3", MajorThird(), "Bb3");
            yield return new TestCaseData("G3", MajorThird(), "B3");
            yield return new TestCaseData("G#3", MajorThird(), "B#3");
            yield return new TestCaseData("Ab3", MajorThird(), "C4");
            yield return new TestCaseData("A3", MajorThird(), "C#4");
            yield return new TestCaseData("A#3", MajorThird(), "C##4");
            yield return new TestCaseData("Bb3", MajorThird(), "D4");
            yield return new TestCaseData("B3", MajorThird(), "D#4");
            yield return new TestCaseData("B#3", MajorThird(), "D##4");

            yield return new TestCaseData("Cb3", PerfectFourth(), "Fb3");
            yield return new TestCaseData("C3", PerfectFourth(), "F3");
            yield return new TestCaseData("C#3", PerfectFourth(), "F#3");
            yield return new TestCaseData("Db3", PerfectFourth(), "Gb3");
            yield return new TestCaseData("D3", PerfectFourth(), "G3");
            yield return new TestCaseData("D#3", PerfectFourth(), "G#3");
            yield return new TestCaseData("Eb3", PerfectFourth(), "Ab3");
            yield return new TestCaseData("E3", PerfectFourth(), "A3");
            yield return new TestCaseData("E#3", PerfectFourth(), "A#3");
            yield return new TestCaseData("Fb3", PerfectFourth(), "Bbb3");
            yield return new TestCaseData("F3", PerfectFourth(), "Bb3");
            yield return new TestCaseData("F#3", PerfectFourth(), "B3");
            yield return new TestCaseData("Gb3", PerfectFourth(), "Cb4");
            yield return new TestCaseData("G3", PerfectFourth(), "C4");
            yield return new TestCaseData("G#3", PerfectFourth(), "C#4");
            yield return new TestCaseData("Ab3", PerfectFourth(), "Db4");
            yield return new TestCaseData("A3", PerfectFourth(), "D4");
            yield return new TestCaseData("A#3", PerfectFourth(), "D#4");
            yield return new TestCaseData("Bb3", PerfectFourth(), "Eb4");
            yield return new TestCaseData("B3", PerfectFourth(), "E4");
            yield return new TestCaseData("B#3", PerfectFourth(), "E#4");

            yield return new TestCaseData("Cb3", DiminishedFifth(), "Gbb3");
            yield return new TestCaseData("C3", DiminishedFifth(), "Gb3");
            yield return new TestCaseData("C#3", DiminishedFifth(), "G3");
            yield return new TestCaseData("Db3", DiminishedFifth(), "Abb3");
            yield return new TestCaseData("D3", DiminishedFifth(), "Ab3");
            yield return new TestCaseData("D#3", DiminishedFifth(), "A3");
            yield return new TestCaseData("Eb3", DiminishedFifth(), "Bbb3");
            yield return new TestCaseData("E3", DiminishedFifth(), "Bb3");
            yield return new TestCaseData("E#3", DiminishedFifth(), "B3");
            yield return new TestCaseData("Fb3", DiminishedFifth(), "Cbb4");
            yield return new TestCaseData("F3", DiminishedFifth(), "Cb4");
            yield return new TestCaseData("F#3", DiminishedFifth(), "C4");
            yield return new TestCaseData("Gb3", DiminishedFifth(), "Dbb4");
            yield return new TestCaseData("G3", DiminishedFifth(), "Db4");
            yield return new TestCaseData("G#3", DiminishedFifth(), "D4");
            yield return new TestCaseData("Ab3", DiminishedFifth(), "Ebb4");
            yield return new TestCaseData("A3", DiminishedFifth(), "Eb4");
            yield return new TestCaseData("A#3", DiminishedFifth(), "E4");
            yield return new TestCaseData("Bb3", DiminishedFifth(), "Fb4");
            yield return new TestCaseData("B3", DiminishedFifth(), "F4");
            yield return new TestCaseData("B#3", DiminishedFifth(), "F#4");

            yield return new TestCaseData("Cb3", PerfectFifth(), "Gb3");
            yield return new TestCaseData("C3", PerfectFifth(), "G3");
            yield return new TestCaseData("C#3", PerfectFifth(), "G#3");
            yield return new TestCaseData("Db3", PerfectFifth(), "Ab3");
            yield return new TestCaseData("D3", PerfectFifth(), "A3");
            yield return new TestCaseData("D#3", PerfectFifth(), "A#3");
            yield return new TestCaseData("Eb3", PerfectFifth(), "Bb3");
            yield return new TestCaseData("E3", PerfectFifth(), "B3");
            yield return new TestCaseData("E#3", PerfectFifth(), "B#3");
            yield return new TestCaseData("Fb3", PerfectFifth(), "Cb4");
            yield return new TestCaseData("F3", PerfectFifth(), "C4");
            yield return new TestCaseData("F#3", PerfectFifth(), "C#4");
            yield return new TestCaseData("Gb3", PerfectFifth(), "Db4");
            yield return new TestCaseData("G3", PerfectFifth(), "D4");
            yield return new TestCaseData("G#3", PerfectFifth(), "D#4");
            yield return new TestCaseData("Ab3", PerfectFifth(), "Eb4");
            yield return new TestCaseData("A3", PerfectFifth(), "E4");
            yield return new TestCaseData("A#3", PerfectFifth(), "E#4");
            yield return new TestCaseData("Bb3", PerfectFifth(), "F4");
            yield return new TestCaseData("B3", PerfectFifth(), "F#4");
            yield return new TestCaseData("B#3", PerfectFifth(), "F##4");

            yield return new TestCaseData("Cb3", MinorSixth(), "Abb3");
            yield return new TestCaseData("C3", MinorSixth(), "Ab3");
            yield return new TestCaseData("C#3", MinorSixth(), "A3");
            yield return new TestCaseData("Db3", MinorSixth(), "Bbb3");
            yield return new TestCaseData("D3", MinorSixth(), "Bb3");
            yield return new TestCaseData("D#3", MinorSixth(), "B3");
            yield return new TestCaseData("Eb3", MinorSixth(), "Cb4");
            yield return new TestCaseData("E3", MinorSixth(), "C4");
            yield return new TestCaseData("E#3", MinorSixth(), "C#4");
            yield return new TestCaseData("Fb3", MinorSixth(), "Dbb4");
            yield return new TestCaseData("F3", MinorSixth(), "Db4");
            yield return new TestCaseData("F#3", MinorSixth(), "D4");
            yield return new TestCaseData("Gb3", MinorSixth(), "Ebb4");
            yield return new TestCaseData("G3", MinorSixth(), "Eb4");
            yield return new TestCaseData("G#3", MinorSixth(), "E4");
            yield return new TestCaseData("Ab3", MinorSixth(), "Fb4");
            yield return new TestCaseData("A3", MinorSixth(), "F4");
            yield return new TestCaseData("A#3", MinorSixth(), "F#4");
            yield return new TestCaseData("Bb3", MinorSixth(), "Gb4");
            yield return new TestCaseData("B3", MinorSixth(), "G4");
            yield return new TestCaseData("B#3", MinorSixth(), "G#");

            yield return new TestCaseData("Cb3", MajorSixth(), "Ab3");
            yield return new TestCaseData("C3", MajorSixth(), "A3");
            yield return new TestCaseData("C#3", MajorSixth(), "A#3");
            yield return new TestCaseData("Db3", MajorSixth(), "Bb3");
            yield return new TestCaseData("D3", MajorSixth(), "B3");
            yield return new TestCaseData("D#3", MajorSixth(), "B#3");
            yield return new TestCaseData("Eb3", MajorSixth(), "C4");
            yield return new TestCaseData("E3", MajorSixth(), "C#4");
            yield return new TestCaseData("E#3", MajorSixth(), "C##4");
            yield return new TestCaseData("Fb3", MajorSixth(), "Db4");
            yield return new TestCaseData("F3", MajorSixth(), "D4");
            yield return new TestCaseData("F#3", MajorSixth(), "D#4");
            yield return new TestCaseData("Gb3", MajorSixth(), "Eb4");
            yield return new TestCaseData("G3", MajorSixth(), "E4");
            yield return new TestCaseData("G#3", MajorSixth(), "E#4");
            yield return new TestCaseData("Ab3", MajorSixth(), "F4");
            yield return new TestCaseData("A3", MajorSixth(), "F#4");
            yield return new TestCaseData("A#3", MajorSixth(), "F##4");
            yield return new TestCaseData("Bb3", MajorSixth(), "G4");
            yield return new TestCaseData("B3", MajorSixth(), "G#4");
            yield return new TestCaseData("B#3", MajorSixth(), "G##4");

            yield return new TestCaseData("Cb3", MinorSeventh(), "Bbb3");
            yield return new TestCaseData("C3", MinorSeventh(), "Bb3");
            yield return new TestCaseData("C#3", MinorSeventh(), "B3");
            yield return new TestCaseData("Db3", MinorSeventh(), "Cb4");
            yield return new TestCaseData("D3", MinorSeventh(), "C4");
            yield return new TestCaseData("D#3", MinorSeventh(), "C#4");
            yield return new TestCaseData("Eb3", MinorSeventh(), "Db4");
            yield return new TestCaseData("E3", MinorSeventh(), "D4");
            yield return new TestCaseData("E#3", MinorSeventh(), "D#4");
            yield return new TestCaseData("Fb3", MinorSeventh(), "Ebb4");
            yield return new TestCaseData("F3", MinorSeventh(), "Eb4");
            yield return new TestCaseData("F#3", MinorSeventh(), "E4");
            yield return new TestCaseData("Gb3", MinorSeventh(), "Fb4");
            yield return new TestCaseData("G3", MinorSeventh(), "F4");
            yield return new TestCaseData("G#3", MinorSeventh(), "F#4");
            yield return new TestCaseData("Ab3", MinorSeventh(), "Gb4");
            yield return new TestCaseData("A3", MinorSeventh(), "G4");
            yield return new TestCaseData("A#3", MinorSeventh(), "G#4");
            yield return new TestCaseData("Bb3", MinorSeventh(), "Ab4");
            yield return new TestCaseData("B3", MinorSeventh(), "A4");
            yield return new TestCaseData("B#3", MinorSeventh(), "A#4");

            yield return new TestCaseData("Cb3", MajorSeventh(), "Bb3");
            yield return new TestCaseData("C3", MajorSeventh(), "B3");
            yield return new TestCaseData("C#3", MajorSeventh(), "B#3");
            yield return new TestCaseData("Db3", MajorSeventh(), "C4");
            yield return new TestCaseData("D3", MajorSeventh(), "C#4");
            yield return new TestCaseData("D#3", MajorSeventh(), "C##4");
            yield return new TestCaseData("Eb3", MajorSeventh(), "D4");
            yield return new TestCaseData("E3", MajorSeventh(), "D#4");
            yield return new TestCaseData("E#3", MajorSeventh(), "D##4");
            yield return new TestCaseData("Fb3", MajorSeventh(), "Eb4");
            yield return new TestCaseData("F3", MajorSeventh(), "E4");
            yield return new TestCaseData("F#3", MajorSeventh(), "E#4");
            yield return new TestCaseData("Gb3", MajorSeventh(), "F4");
            yield return new TestCaseData("G3", MajorSeventh(), "F#4");
            yield return new TestCaseData("G#3", MajorSeventh(), "F##4");
            yield return new TestCaseData("Ab3", MajorSeventh(), "G4");
            yield return new TestCaseData("A3", MajorSeventh(), "G#4");
            yield return new TestCaseData("A#3", MajorSeventh(), "G##4");
            yield return new TestCaseData("Bb3", MajorSeventh(), "A4");
            yield return new TestCaseData("B3", MajorSeventh(), "A#4");
            yield return new TestCaseData("B#3", MajorSeventh(), "A##4");

            yield return new TestCaseData("Cb3", Octave(), "Cb4");
            yield return new TestCaseData("C3", Octave(), "C4");
            yield return new TestCaseData("C#3", Octave(), "C#4");
            yield return new TestCaseData("Db3", Octave(), "Db4");
            yield return new TestCaseData("D3", Octave(), "D4");
            yield return new TestCaseData("D#3", Octave(), "D#4");
            yield return new TestCaseData("Eb3", Octave(), "Eb4");
            yield return new TestCaseData("E3", Octave(), "E4");
            yield return new TestCaseData("E#3", Octave(), "E#4");
            yield return new TestCaseData("Fb3", Octave(), "Fb4");
            yield return new TestCaseData("F3", Octave(), "F4");
            yield return new TestCaseData("F#3", Octave(), "F#4");
            yield return new TestCaseData("Gb3", Octave(), "Gb4");
            yield return new TestCaseData("G3", Octave(), "G4");
            yield return new TestCaseData("G#3", Octave(), "G#4");
            yield return new TestCaseData("Ab3", Octave(), "Ab4");
            yield return new TestCaseData("A3", Octave(), "A4");
            yield return new TestCaseData("A#3", Octave(), "A#4");
            yield return new TestCaseData("Bb3", Octave(), "Bb4");
            yield return new TestCaseData("B3", Octave(), "B4");
            yield return new TestCaseData("B#3", Octave(), "B#4");
        }

        [Test]
        [TestCaseSource(nameof(TransposeSource))]
        public static void Transpose(string start, Core.Interval.Interval interval, string expected)
        {
            Assert.AreEqual(Note.Parse(expected), Note.Parse(start).Transpose(interval));
        }
    }
}
