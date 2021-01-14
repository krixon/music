using System;
using System.Linq;
using Krixon.Music.Core.Scales;
using NUnit.Framework;

namespace Krixon.Music.Core.Test.Scales
{
    [TestFixture]
    public class ScaleTests
    {
        [Test]
        [TestCase("Cb", new[] {"Cb", "Db", "Eb", "Fb", "Gb", "Ab", "Bb"})]
        [TestCase("C", new[] {"C", "D", "E", "F", "G", "A", "B"})]
        [TestCase("C#", new[] {"C#", "D#", "E#", "F#", "G#", "A#", "B#"})]
        [TestCase("Db", new[] {"Db", "Eb", "F", "Gb", "Ab", "Bb", "C5"})]
        [TestCase("D", new[] {"D", "E", "F#", "G", "A", "B", "C#5"})]
        [TestCase("D#", new[] {"D#", "E#", "F##", "G#", "A#", "B#", "C##5"})]
        [TestCase("Eb", new[] {"Eb", "F", "G", "Ab", "Bb", "C5", "D5"})]
        [TestCase("E", new[] {"E", "F#", "G#", "A", "B", "C#5", "D#5"})]
        [TestCase("E#", new[] {"E#", "F##", "G##", "A#", "B#", "C##5", "D##5"})]
        [TestCase("Fb", new[] {"Fb", "Gb", "Ab", "Bbb", "Cb5", "Db5", "Eb5"})]
        [TestCase("F", new[] {"F", "G", "A", "Bb", "C5", "D5", "E5"})]
        [TestCase("F#", new[] {"F#", "G#", "A#", "B", "C#5", "D#5", "E#5"})]
        [TestCase("Gb", new[] {"Gb", "Ab", "Bb", "Cb5", "Db5", "Eb5", "F5"})]
        [TestCase("G", new[] {"G", "A", "B", "C5", "D5", "E5", "F#5"})]
        [TestCase("G#", new[] {"G#", "A#", "B#", "C#5", "D#5", "E#5", "F##5"})]
        [TestCase("Ab", new[] {"Ab", "Bb", "C5", "Db5", "Eb5", "F5", "G5"})]
        [TestCase("A", new[] {"A", "B", "C#5", "D5", "E5", "F#5", "G#5"})]
        [TestCase("A#", new[] {"A#", "B#", "C##5", "D#5", "E#5", "F##5", "G##5"})]
        [TestCase("Bb", new[] {"Bb", "C5", "D5", "Eb5", "F5", "G5", "A5"})]
        [TestCase("B", new[] {"B", "C#5", "D#5", "E5", "F#5", "G#5", "A#5"})]
        [TestCase("B#", new[] {"B#", "C##5", "D##5", "E#5", "F##5", "G##5", "A##5"})]
        public static void Ionian(string tonic, string[] expected)
        {
            TestNotes(tonic, expected, Scale.Ionian);
        }

        [Test]
        [TestCase("Cb", new[] {"Cb", "Db", "Ebb", "Fb", "Gb", "Ab", "Bbb"})]
        [TestCase("C", new[] {"C", "D", "Eb", "F", "G", "A", "Bb"})]
        [TestCase("C#", new[] {"C#", "D#", "E", "F#", "G#", "A#", "B"})]
        [TestCase("Db", new[] {"Db", "Eb", "Fb", "Gb", "Ab", "Bb", "Cb5"})]
        [TestCase("D", new[] {"D", "E", "F", "G", "A", "B", "C5"})]
        [TestCase("D#", new[] {"D#", "E#", "F#", "G#", "A#", "B#", "C#5"})]
        [TestCase("Eb", new[] {"Eb", "F", "Gb", "Ab", "Bb", "C5", "Db5"})]
        [TestCase("E", new[] {"E", "F#", "G", "A", "B", "C#5", "D5"})]
        [TestCase("E#", new[] {"E#", "F##", "G#", "A#", "B#", "C##5", "D#5"})]
        [TestCase("Fb", new[] {"Fb", "Gb", "Abb", "Bbb", "Cb5", "Db5", "Ebb5"})]
        [TestCase("F", new[] {"F", "G", "Ab", "Bb", "C5", "D5", "Eb5"})]
        [TestCase("F#", new[] {"F#", "G#", "A", "B", "C#5", "D#5", "E5"})]
        [TestCase("Gb", new[] {"Gb", "Ab", "Bbb", "Cb5", "Db5", "Eb5", "Fb5"})]
        [TestCase("G", new[] {"G", "A", "Bb", "C5", "D5", "E5", "F5"})]
        [TestCase("G#", new[] {"G#", "A#", "B", "C#5", "D#5", "E#5", "F#5"})]
        [TestCase("Ab", new[] {"Ab", "Bb", "Cb5", "Db5", "Eb5", "F5", "Gb5"})]
        [TestCase("A", new[] {"A", "B", "C5", "D5", "E5", "F#5", "G5"})]
        [TestCase("A#", new[] {"A#", "B#", "C#5", "D#5", "E#5", "F##5", "G#5"})]
        [TestCase("Bb", new[] {"Bb", "C5", "Db5", "Eb5", "F5", "G5", "Ab5"})]
        [TestCase("B", new[] {"B", "C#5", "D5", "E5", "F#5", "G#5", "A5"})]
        [TestCase("B#", new[] {"B#", "C##5", "D#5", "E#5", "F##5", "G##5", "A#5"})]
        public static void Dorian(string tonic, string[] expected)
        {
            TestNotes(tonic, expected, Scale.Dorian);
        }

        [Test]
        [TestCase("Cb", new[] {"Cb", "Dbb", "Ebb", "Fb", "Gb", "Abb", "Bbb"})]
        [TestCase("C", new[] {"C", "Db", "Eb", "F", "G", "Ab", "Bb"})]
        [TestCase("C#", new[] {"C#", "D", "E", "F#", "G#", "A", "B"})]
        [TestCase("Db", new[] {"Db", "Ebb", "Fb", "Gb", "Ab", "Bbb", "Cb5"})]
        [TestCase("D", new[] {"D", "Eb", "F", "G", "A", "Bb", "C5"})]
        [TestCase("D#", new[] {"D#", "E", "F#", "G#", "A#", "B", "C#5"})]
        [TestCase("Eb", new[] {"Eb", "Fb", "Gb", "Ab", "Bb", "Cb5", "Db5"})]
        [TestCase("E", new[] {"E", "F", "G", "A", "B", "C5", "D5"})]
        [TestCase("E#", new[] {"E#", "F#", "G#", "A#", "B#", "C#5", "D#5"})]
        [TestCase("Fb", new[] {"Fb", "Gbb", "Abb", "Bbb", "Cb5", "Dbb5", "Ebb5"})]
        [TestCase("F", new[] {"F", "Gb", "Ab", "Bb", "C5", "Db5", "Eb5"})]
        [TestCase("F#", new[] {"F#", "G", "A", "B", "C#5", "D5", "E5"})]
        [TestCase("Gb", new[] {"Gb", "Abb", "Bbb", "Cb5", "Db5", "Ebb5", "Fb5"})]
        [TestCase("G", new[] {"G", "Ab", "Bb", "C5", "D5", "Eb5", "F5"})]
        [TestCase("G#", new[] {"G#", "A", "B", "C#5", "D#5", "E5", "F#5"})]
        [TestCase("Ab", new[] {"Ab", "Bbb", "Cb5", "Db5", "Eb5", "Fb5", "Gb5"})]
        [TestCase("A", new[] {"A", "Bb", "C5", "D5", "E5", "F5", "G5"})]
        [TestCase("A#", new[] {"A#", "B", "C#5", "D#5", "E#5", "F#5", "G#5"})]
        [TestCase("Bb", new[] {"Bb", "Cb5", "Db5", "Eb5", "F5", "Gb5", "Ab5"})]
        [TestCase("B", new[] {"B", "C5", "D5", "E5", "F#5", "G5", "A5"})]
        [TestCase("B#", new[] {"B#", "C#5", "D#5", "E#5", "F##5", "G#5", "A#5"})]
        public static void Phrygian(string tonic, string[] expected)
        {
            TestNotes(tonic, expected, Scale.Phrygian);
        }

        [Test]
        [TestCase("Cb", new[] {"Cb", "Db", "Eb", "F", "Gb", "Ab", "Bb"})]
        [TestCase("C", new[] {"C", "D", "E", "F#", "G", "A", "B"})]
        [TestCase("C#", new[] {"C#", "D#", "E#", "F##", "G#", "A#", "B#"})]
        [TestCase("Db", new[] {"Db", "Eb", "F", "G", "Ab", "Bb", "C5"})]
        [TestCase("D", new[] {"D", "E", "F#", "G#", "A", "B", "C#5"})]
        [TestCase("D#", new[] {"D#", "E#", "F##", "G##", "A#", "B#", "C##5"})]
        [TestCase("Eb", new[] {"Eb", "F", "G", "A", "Bb", "C5", "D5"})]
        [TestCase("E", new[] {"E", "F#", "G#", "A#", "B", "C#5", "D#5"})]
        [TestCase("E#", new[] {"E#", "F##", "G##", "A##", "B#", "C##5", "D##5"})]
        [TestCase("Fb", new[] {"Fb", "Gb", "Ab", "Bb", "Cb5", "Db5", "Eb5"})]
        [TestCase("F", new[] {"F", "G", "A", "B", "C5", "D5", "E5"})]
        [TestCase("F#", new[] {"F#", "G#", "A#", "B#", "C#5", "D#5", "E#5"})]
        [TestCase("Gb", new[] {"Gb", "Ab", "Bb", "C5", "Db5", "Eb5", "F5"})]
        [TestCase("G", new[] {"G", "A", "B", "C#5", "D5", "E5", "F#5"})]
        [TestCase("G#", new[] {"G#", "A#", "B#", "C##5", "D#5", "E#5", "F##5"})]
        [TestCase("Ab", new[] {"Ab", "Bb", "C5", "D5", "Eb5", "F5", "G5"})]
        [TestCase("A", new[] {"A", "B", "C#5", "D#5", "E5", "F#5", "G#5"})]
        [TestCase("A#", new[] {"A#", "B#", "C##5", "D##5", "E#5", "F##5", "G##5"})]
        [TestCase("Bb", new[] {"Bb", "C5", "D5", "E5", "F5", "G5", "A5"})]
        [TestCase("B", new[] {"B", "C#5", "D#5", "E#5", "F#5", "G#5", "A#5"})]
        [TestCase("B#", new[] {"B#", "C##5", "D##5", "E##5", "F##5", "G##5", "A##5"})]
        public static void Lydian(string tonic, string[] expected)
        {
            TestNotes(tonic, expected, Scale.Lydian);
        }

        [Test]
        [TestCase("Cb", new[] {"Cb", "Db", "Eb", "Fb", "Gb", "Ab", "Bbb"})]
        [TestCase("C", new[] {"C", "D", "E", "F", "G", "A", "Bb"})]
        [TestCase("C#", new[] {"C#", "D#", "E#", "F#", "G#", "A#", "B"})]
        [TestCase("Db", new[] {"Db", "Eb", "F", "Gb", "Ab", "Bb", "Cb5"})]
        [TestCase("D", new[] {"D", "E", "F#", "G", "A", "B", "C5"})]
        [TestCase("D#", new[] {"D#", "E#", "F##", "G#", "A#", "B#", "C#5"})]
        [TestCase("Eb", new[] {"Eb", "F", "G", "Ab", "Bb", "C5", "Db5"})]
        [TestCase("E", new[] {"E", "F#", "G#", "A", "B", "C#5", "D5"})]
        [TestCase("E#", new[] {"E#", "F##", "G##", "A#", "B#", "C##5", "D#5"})]
        [TestCase("Fb", new[] {"Fb", "Gb", "Ab", "Bbb", "Cb5", "Db5", "Ebb5"})]
        [TestCase("F", new[] {"F", "G", "A", "Bb", "C5", "D5", "Eb5"})]
        [TestCase("F#", new[] {"F#", "G#", "A#", "B", "C#5", "D#5", "E5"})]
        [TestCase("Gb", new[] {"Gb", "Ab", "Bb", "Cb5", "Db5", "Eb5", "Fb5"})]
        [TestCase("G", new[] {"G", "A", "B", "C5", "D5", "E5", "F5"})]
        [TestCase("G#", new[] {"G#", "A#", "B#", "C#5", "D#5", "E#5", "F#5"})]
        [TestCase("Ab", new[] {"Ab", "Bb", "C5", "Db5", "Eb5", "F5", "Gb5"})]
        [TestCase("A", new[] {"A", "B", "C#5", "D5", "E5", "F#5", "G5"})]
        [TestCase("A#", new[] {"A#", "B#", "C##5", "D#5", "E#5", "F##5", "G#5"})]
        [TestCase("Bb", new[] {"Bb", "C5", "D5", "Eb5", "F5", "G5", "Ab5"})]
        [TestCase("B", new[] {"B", "C#5", "D#5", "E5", "F#5", "G#5", "A5"})]
        [TestCase("B#", new[] {"B#", "C##5", "D##5", "E#5", "F##5", "G##5", "A#5"})]
        public static void Mixolydian(string tonic, string[] expected)
        {
            TestNotes(tonic, expected, Scale.Mixolydian);
        }

        [Test]
        [TestCase("Cb", new[] {"Cb", "Db", "Ebb", "Fb", "Gb", "Abb", "Bbb"})]
        [TestCase("C", new[] {"C", "D", "Eb", "F", "G", "Ab", "Bb"})]
        [TestCase("C#", new[] {"C#", "D#", "E", "F#", "G#", "A", "B"})]
        [TestCase("Db", new[] {"Db", "Eb", "Fb", "Gb", "Ab", "Bbb", "Cb5"})]
        [TestCase("D", new[] {"D", "E", "F", "G", "A", "Bb", "C5"})]
        [TestCase("D#", new[] {"D#", "E#", "F#", "G#", "A#", "B", "C#5"})]
        [TestCase("Eb", new[] {"Eb", "F", "Gb", "Ab", "Bb", "Cb5", "Db5"})]
        [TestCase("E", new[] {"E", "F#", "G", "A", "B", "C5", "D5"})]
        [TestCase("E#", new[] {"E#", "F##", "G#", "A#", "B#", "C#5", "D#5"})]
        [TestCase("Fb", new[] {"Fb", "Gb", "Abb", "Bbb", "Cb5", "Dbb5", "Ebb5"})]
        [TestCase("F", new[] {"F", "G", "Ab", "Bb", "C5", "Db5", "Eb5"})]
        [TestCase("F#", new[] {"F#", "G#", "A", "B", "C#5", "D5", "E5"})]
        [TestCase("Gb", new[] {"Gb", "Ab", "Bbb", "Cb5", "Db5", "Ebb5", "Fb5"})]
        [TestCase("G", new[] {"G", "A", "Bb", "C5", "D5", "Eb5", "F5"})]
        [TestCase("G#", new[] {"G#", "A#", "B", "C#5", "D#5", "E5", "F#5"})]
        [TestCase("Ab", new[] {"Ab", "Bb", "Cb5", "Db5", "Eb5", "Fb5", "Gb5"})]
        [TestCase("A", new[] {"A", "B", "C5", "D5", "E5", "F5", "G5"})]
        [TestCase("A#", new[] {"A#", "B#", "C#5", "D#5", "E#5", "F#5", "G#5"})]
        [TestCase("Bb", new[] {"Bb", "C5", "Db5", "Eb5", "F5", "Gb5", "Ab5"})]
        [TestCase("B", new[] {"B", "C#5", "D5", "E5", "F#5", "G5", "A5"})]
        [TestCase("B#", new[] {"B#", "C##5", "D#5", "E#5", "F##5", "G#5", "A#5"})]
        public static void Aeolian(string tonic, string[] expected)
        {
            TestNotes(tonic, expected, Scale.Aeolian);
        }

        [Test]
        [TestCase("Cb", new[] {"Cb", "Dbb", "Ebb", "Fb", "Gbb", "Abb", "Bbb"})]
        [TestCase("C", new[] {"C", "Db", "Eb", "F", "Gb", "Ab", "Bb"})]
        [TestCase("C#", new[] {"C#", "D", "E", "F#", "G", "A", "B"})]
        [TestCase("Db", new[] {"Db", "Ebb", "Fb", "Gb", "Abb", "Bbb", "Cb5"})]
        [TestCase("D", new[] {"D", "Eb", "F", "G", "Ab", "Bb", "C5"})]
        [TestCase("D#", new[] {"D#", "E", "F#", "G#", "A", "B", "C#5"})]
        [TestCase("Eb", new[] {"Eb", "Fb", "Gb", "Ab", "Bbb", "Cb5", "Db5"})]
        [TestCase("E", new[] {"E", "F", "G", "A", "Bb", "C5", "D5"})]
        [TestCase("E#", new[] {"E#", "F#", "G#", "A#", "B", "C#5", "D#5"})]
        [TestCase("Fb", new[] {"Fb", "Gbb", "Abb", "Bbb", "Cbb5", "Dbb5", "Ebb5"})]
        [TestCase("F", new[] {"F", "Gb", "Ab", "Bb", "Cb5", "Db5", "Eb5"})]
        [TestCase("F#", new[] {"F#", "G", "A", "B", "C5", "D5", "E5"})]
        [TestCase("Gb", new[] {"Gb", "Abb", "Bbb", "Cb5", "Dbb5", "Ebb5", "Fb5"})]
        [TestCase("G", new[] {"G", "Ab", "Bb", "C5", "Db5", "Eb5", "F5"})]
        [TestCase("G#", new[] {"G#", "A", "B", "C#5", "D5", "E5", "F#5"})]
        [TestCase("Ab", new[] {"Ab", "Bbb", "Cb5", "Db5", "Ebb5", "Fb5", "Gb5"})]
        [TestCase("A", new[] {"A", "Bb", "C5", "D5", "Eb5", "F5", "G5"})]
        [TestCase("A#", new[] {"A#", "B", "C#5", "D#5", "E5", "F#5", "G#5"})]
        [TestCase("Bb", new[] {"Bb", "Cb5", "Db5", "Eb5", "Fb5", "Gb5", "Ab5"})]
        [TestCase("B", new[] {"B", "C5", "D5", "E5", "F5", "G5", "A5"})]
        [TestCase("B#", new[] {"B#", "C#5", "D#5", "E#5", "F#5", "G#5", "A#5"})]
        public static void Locrian(string tonic, string[] expected)
        {
            TestNotes(tonic, expected, Scale.Locrian);
        }

        [Test]
        [TestCase("Cb", new[] {"Cb", "Db", "Ebb", "Fb", "Gb", "Abb", "Bb"})]
        [TestCase("C", new[] {"C", "D", "Eb", "F", "G", "Ab", "B"})]
        [TestCase("C#", new[] {"C#", "D#", "E", "F#", "G#", "A", "B#"})]
        [TestCase("Db", new[] {"Db", "Eb", "Fb", "Gb", "Ab", "Bbb", "C5"})]
        [TestCase("D", new[] {"D", "E", "F", "G", "A", "Bb", "C#5"})]
        [TestCase("D#", new[] {"D#", "E#", "F#", "G#", "A#", "B", "C##5"})]
        [TestCase("Eb", new[] {"Eb", "F", "Gb", "Ab", "Bb", "Cb5", "D5"})]
        [TestCase("E", new[] {"E", "F#", "G", "A", "B", "C5", "D#5"})]
        [TestCase("E#", new[] {"E#", "F##", "G#", "A#", "B#", "C#5", "D##5"})]
        [TestCase("Fb", new[] {"Fb", "Gb", "Abb", "Bbb", "Cb5", "Dbb5", "Eb5"})]
        [TestCase("F", new[] {"F", "G", "Ab", "Bb", "C5", "Db5", "E5"})]
        [TestCase("F#", new[] {"F#", "G#", "A", "B", "C#5", "D5", "E#5"})]
        [TestCase("Gb", new[] {"Gb", "Ab", "Bbb", "Cb5", "Db5", "Ebb5", "F5"})]
        [TestCase("G", new[] {"G", "A", "Bb", "C5", "D5", "Eb5", "F#5"})]
        [TestCase("G#", new[] {"G#", "A#", "B", "C#5", "D#5", "E5", "F##5"})]
        [TestCase("Ab", new[] {"Ab", "Bb", "Cb5", "Db5", "Eb5", "Fb5", "G5"})]
        [TestCase("A", new[] {"A", "B", "C5", "D5", "E5", "F5", "G#5"})]
        [TestCase("A#", new[] {"A#", "B#", "C#5", "D#5", "E#5", "F#5", "G##5"})]
        [TestCase("Bb", new[] {"Bb", "C5", "Db5", "Eb5", "F5", "Gb5", "A5"})]
        [TestCase("B", new[] {"B", "C#5", "D5", "E5", "F#5", "G5", "A#5"})]
        [TestCase("B#", new[] {"B#", "C##5", "D#5", "E#5", "F##5", "G#5", "A##5"})]
        public static void HarmonicMinor(string tonic, string[] expected)
        {
            TestNotes(tonic, expected, Scale.HarmonicMinor);
        }

        private static void TestNotes(string tonic, string[] expected, Func<Note, Scale> ctor)
        {
            var scale = ctor(Note.Parse(tonic));
            var notes = scale.Notes.ToArray();

            Assert.AreEqual(expected.Length, scale.Length);

            for (var i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(notes[i], Note.Parse(expected[i]));
            }
        }
    }
}
