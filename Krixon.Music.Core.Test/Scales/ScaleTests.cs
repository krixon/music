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

        [Test]
        [TestCase("Cb", Direction.Ascending, new[] {"Cb", "Db", "Ebb", "Fb", "Gb", "Ab", "Bb"})]
        [TestCase("Cb", Direction.Descending, new[] {"Bbb", "Abb", "Gb", "Fb", "Ebb", "Db", "Cb"})]
        [TestCase("C", Direction.Ascending, new[] {"C", "D", "Eb", "F", "G", "A", "B"})]
        [TestCase("C", Direction.Descending, new[] {"Bb", "Ab", "G", "F", "Eb", "D", "C"})]
        [TestCase("C#", Direction.Ascending, new[] {"C#", "D#", "E", "F#", "G#", "A#", "B#"})]
        [TestCase("C#", Direction.Descending, new[] {"B", "A", "G#", "F#", "E", "D#", "C#"})]
        [TestCase("Db", Direction.Ascending, new[] {"Db", "Eb", "Fb", "Gb", "Ab", "Bb", "C5"})]
        [TestCase("Db", Direction.Descending, new[] {"Cb5", "Bbb", "Ab", "Gb", "Fb", "Eb", "Db"})]
        [TestCase("D", Direction.Ascending, new[] {"D", "E", "F", "G", "A", "B", "C#5"})]
        [TestCase("D", Direction.Descending, new[] {"C5", "Bb", "A", "G", "F", "E", "D"})]
        [TestCase("D#", Direction.Ascending, new[] {"D#", "E#", "F#", "G#", "A#", "B#", "C##5"})]
        [TestCase("D#", Direction.Descending, new[] {"C#5", "B", "A#", "G#", "F#", "E#", "D#"})]
        [TestCase("Eb", Direction.Ascending, new[] {"Eb", "F", "Gb", "Ab", "Bb", "C5", "D5"})]
        [TestCase("Eb", Direction.Descending, new[] {"Db5", "Cb5", "Bb", "Ab", "Gb", "F", "Eb"})]
        [TestCase("E", Direction.Ascending, new[] {"E", "F#", "G", "A", "B", "C#5", "D#5"})]
        [TestCase("E", Direction.Descending, new[] {"D5", "C5", "B", "A", "G", "F#", "E"})]
        [TestCase("E#", Direction.Ascending, new[] {"E#", "F##", "G#", "A#", "B#", "C##5", "D##5"})]
        [TestCase("E#", Direction.Descending, new[] {"D#5", "C#5", "B#", "A#", "G#", "F##", "E#"})]
        [TestCase("Fb", Direction.Ascending, new[] {"Fb", "Gb", "Abb", "Bbb", "Cb5", "Db5", "Eb5"})]
        [TestCase("Fb", Direction.Descending, new[] {"Ebb5", "Dbb5", "Cb5", "Bbb", "Abb", "Gb", "Fb"})]
        [TestCase("F", Direction.Ascending, new[] {"F", "G", "Ab", "Bb", "C5", "D5", "E5"})]
        [TestCase("F", Direction.Descending, new[] {"Eb5", "Db5", "C5", "Bb", "Ab", "G", "F"})]
        [TestCase("F#", Direction.Ascending, new[] {"F#", "G#", "A", "B", "C#5", "D#5", "E#5"})]
        [TestCase("F#", Direction.Descending, new[] {"E5", "D5", "C#5", "B", "A", "G#", "F#"})]
        [TestCase("Gb", Direction.Ascending, new[] {"Gb", "Ab", "Bbb", "Cb5", "Db5", "Eb5", "F5"})]
        [TestCase("Gb", Direction.Descending, new[] {"Fb5", "Ebb5", "Db5", "Cb5", "Bbb", "Ab", "Gb"})]
        [TestCase("G", Direction.Ascending, new[] {"G", "A", "Bb", "C5", "D5", "E5", "F#5"})]
        [TestCase("G", Direction.Descending, new[] {"F5", "Eb5", "D5", "C5", "Bb", "A", "G"})]
        [TestCase("G#", Direction.Ascending, new[] {"G#", "A#", "B", "C#5", "D#5", "E#5", "F##5"})]
        [TestCase("G#", Direction.Descending, new[] {"F#5", "E5", "D#5", "C#5", "B", "A#", "G#"})]
        [TestCase("Ab", Direction.Ascending, new[] {"Ab", "Bb", "Cb5", "Db5", "Eb5", "F5", "G5"})]
        [TestCase("Ab", Direction.Descending, new[] {"Gb5", "Fb5", "Eb5", "Db5", "Cb5", "Bb", "Ab"})]
        [TestCase("A", Direction.Ascending, new[] {"A", "B", "C5", "D5", "E5", "F#5", "G#5"})]
        [TestCase("A", Direction.Descending, new[] {"G5", "F5", "E5", "D5", "C5", "B", "A"})]
        [TestCase("A#", Direction.Ascending, new[] {"A#", "B#", "C#5", "D#5", "E#5", "F##5", "G##5"})]
        [TestCase("A#", Direction.Descending, new[] {"G#5", "F#5", "E#5", "D#5", "C#5", "B#", "A#"})]
        [TestCase("Bb", Direction.Ascending, new[] {"Bb", "C5", "Db5", "Eb5", "F5", "G5", "A5"})]
        [TestCase("Bb", Direction.Descending, new[] {"Ab5", "Gb5", "F5", "Eb5", "Db5", "C5", "Bb"})]
        [TestCase("B", Direction.Ascending, new[] {"B", "C#5", "D5", "E5", "F#5", "G#5", "A#5"})]
        [TestCase("B", Direction.Descending, new[] {"A5", "G5", "F#5", "E5", "D5", "C#5", "B"})]
        [TestCase("B#", Direction.Ascending, new[] {"B#", "C##5", "D#5", "E#5", "F##5", "G##5", "A##5"})]
        [TestCase("B#", Direction.Descending, new[] {"A#5", "G#5", "F##5", "E#5", "D#5", "C##5", "B#"})]
        public static void MelodicMinor(string tonic, Direction direction, string[] expected)
        {
            TestNotes(tonic, expected, Scale.MelodicMinor, direction);
        }

        [Test]
        [TestCase("Cb", new[] {"Cb", "Db", "Eb", "Gb", "Ab"})]
        [TestCase("C", new[] {"C", "D", "E", "G", "A"})]
        [TestCase("C#", new[] {"C#", "D#", "E#", "G#", "A#"})]
        [TestCase("Db", new[] {"Db", "Eb", "F", "Ab", "Bb"})]
        [TestCase("D", new[] {"D", "E", "F#", "A", "B"})]
        [TestCase("D#", new[] {"D#", "E#", "F##", "A#", "B#"})]
        [TestCase("Eb", new[] {"Eb", "F", "G", "Bb", "C5"})]
        [TestCase("E", new[] {"E", "F#", "G#", "B", "C#5"})]
        [TestCase("E#", new[] {"E#", "F##", "G##", "B#", "C##5"})]
        [TestCase("Fb", new[] {"Fb", "Gb", "Ab", "Cb5", "Db5"})]
        [TestCase("F", new[] {"F", "G", "A", "C5", "D5"})]
        [TestCase("F#", new[] {"F#", "G#", "A#", "C#5", "D#5"})]
        [TestCase("Gb", new[] {"Gb", "Ab", "Bb", "Db5", "Eb5"})]
        [TestCase("G", new[] {"G", "A", "B", "D5", "E5"})]
        [TestCase("G#", new[] {"G#", "A#", "B#", "D#5", "E#5"})]
        [TestCase("Ab", new[] {"Ab", "Bb", "C5", "Eb5", "F5"})]
        [TestCase("A", new[] {"A", "B", "C#5", "E5", "F#5"})]
        [TestCase("A#", new[] {"A#", "B#", "C##5", "E#5", "F##5"})]
        [TestCase("Bb", new[] {"Bb", "C5", "D5", "F5", "G5"})]
        [TestCase("B", new[] {"B", "C#5", "D#5", "F#5", "G#5"})]
        [TestCase("B#", new[] {"B#", "C##5", "D##5", "F##5", "G##5"})]
        public static void MajorPentatonic(string tonic, string[] expected)
        {
            TestNotes(tonic, expected, Scale.MajorPentatonic);
        }

        [Test]
        [TestCase("Cb", new[] {"Cb", "Ebb", "Fb", "Gb", "Bbb"})]
        [TestCase("C", new[] {"C", "Eb", "F", "G", "Bb"})]
        [TestCase("C#", new[] {"C#", "E", "F#", "G#", "B"})]
        [TestCase("Db", new[] {"Db", "Fb", "Gb", "Ab", "Cb5"})]
        [TestCase("D", new[] {"D", "F", "G", "A", "C5"})]
        [TestCase("D#", new[] {"D#", "F#", "G#", "A#", "C#5"})]
        [TestCase("Eb", new[] {"Eb", "Gb", "Ab", "Bb", "Db5"})]
        [TestCase("E", new[] {"E", "G", "A", "B", "D5"})]
        [TestCase("E#", new[] {"E#", "G#", "A#", "B#", "D#5"})]
        [TestCase("Fb", new[] {"Fb", "Abb", "Bbb", "Cb5", "Ebb5"})]
        [TestCase("F", new[] {"F", "Ab", "Bb", "C5", "Eb5"})]
        [TestCase("F#", new[] {"F#", "A", "B", "C#5", "E5"})]
        [TestCase("Gb", new[] {"Gb", "Bbb", "Cb5", "Db5", "Fb5"})]
        [TestCase("G", new[] {"G", "Bb", "C5", "D5", "F5"})]
        [TestCase("G#", new[] {"G#", "B", "C#5", "D#5", "F#5"})]
        [TestCase("Ab", new[] {"Ab", "Cb5", "Db5", "Eb5", "Gb5"})]
        [TestCase("A", new[] {"A", "C5", "D5", "E5", "G5"})]
        [TestCase("A#", new[] {"A#", "C#5", "D#5", "E#5", "G#5"})]
        [TestCase("Bb", new[] {"Bb", "Db5", "Eb5", "F5", "Ab5"})]
        [TestCase("B", new[] {"B", "D5", "E5", "F#5", "A5"})]
        [TestCase("B#", new[] {"B#", "D#5", "E#5", "F##5", "A#5"})]
        public static void MinorPentatonic(string tonic, string[] expected)
        {
            TestNotes(tonic, expected, Scale.MinorPentatonic);
        }

        [Test]
        [TestCase("Cb", new[] {"Cb", "Db", "Ebb", "Eb", "Gb", "Ab"})]
        [TestCase("C", new[] {"C", "D", "Eb", "E", "G", "A"})]
        [TestCase("C#", new[] {"C#", "D#", "E", "E#", "G#", "A#"})]
        [TestCase("Db", new[] {"Db", "Eb", "Fb", "F", "Ab", "Bb"})]
        [TestCase("D", new[] {"D", "E", "F", "F#", "A", "B"})]
        [TestCase("D#", new[] {"D#", "E#", "F#", "F##", "A#", "B#"})]
        [TestCase("Eb", new[] {"Eb", "F", "Gb", "G", "Bb", "C5"})]
        [TestCase("E", new[] {"E", "F#", "G", "G#", "B", "C#5"})]
        [TestCase("E#", new[] {"E#", "F##", "G#", "G##", "B#", "C##5"})]
        [TestCase("Fb", new[] {"Fb", "Gb", "Abb", "Ab", "Cb5", "Db5"})]
        [TestCase("F", new[] {"F", "G", "Ab", "A", "C5", "D5"})]
        [TestCase("F#", new[] {"F#", "G#", "A", "A#", "C#5", "D#5"})]
        [TestCase("Gb", new[] {"Gb", "Ab", "Bbb", "Bb", "Db5", "Eb5"})]
        [TestCase("G", new[] {"G", "A", "Bb", "B", "D5", "E5"})]
        [TestCase("G#", new[] {"G#", "A#", "B", "B#", "D#5", "E#5"})]
        [TestCase("Ab", new[] {"Ab", "Bb", "Cb5", "C5", "Eb5", "F5"})]
        [TestCase("A", new[] {"A", "B", "C5", "C#5", "E5", "F#5"})]
        [TestCase("A#", new[] {"A#", "B#", "C#5", "C##5", "E#5", "F##5"})]
        [TestCase("Bb", new[] {"Bb", "C5", "Db5", "D5", "F5", "G5"})]
        [TestCase("B", new[] {"B", "C#5", "D5", "D#5", "F#5", "G#5"})]
        [TestCase("B#", new[] {"B#", "C##5", "D#5", "D##5", "F##5", "G##5"})]
        public static void MajorBlues(string tonic, string[] expected)
        {
            TestNotes(tonic, expected, Scale.MajorBlues);
        }

        [Test]
        [TestCase("Cb", new[] {"Cb", "Ebb", "Fb", "F", "Gb", "Bbb"})]
        [TestCase("C", new[] {"C", "Eb", "F", "F#", "G", "Bb"})]
        [TestCase("C#", new[] {"C#", "E", "F#", "F##", "G#", "B"})]
        [TestCase("Db", new[] {"Db", "Fb", "Gb", "G", "Ab", "Cb5"})]
        [TestCase("D", new[] {"D", "F", "G", "G#", "A", "C5"})]
        [TestCase("D#", new[] {"D#", "F#", "G#", "G##", "A#", "C#5"})]
        [TestCase("Eb", new[] {"Eb", "Gb", "Ab", "A", "Bb", "Db5"})]
        [TestCase("E", new[] {"E", "G", "A", "A#", "B", "D5"})]
        [TestCase("E#", new[] {"E#", "G#", "A#", "A##", "B#", "D#5"})]
        [TestCase("Fb", new[] {"Fb", "Abb", "Bbb", "Bb", "Cb5", "Ebb5"})]
        [TestCase("F", new[] {"F", "Ab", "Bb", "B", "C5", "Eb5"})]
        [TestCase("F#", new[] {"F#", "A", "B", "B#", "C#5", "E5"})]
        [TestCase("Gb", new[] {"Gb", "Bbb", "Cb5", "C5", "Db5", "Fb5"})]
        [TestCase("G", new[] {"G", "Bb", "C5", "C#5", "D5", "F5"})]
        [TestCase("G#", new[] {"G#", "B", "C#5", "C##5", "D#5", "F#5"})]
        [TestCase("Ab", new[] {"Ab", "Cb5", "Db5", "D5", "Eb5", "Gb5"})]
        [TestCase("A", new[] {"A", "C5", "D5", "D#5", "E5", "G5"})]
        [TestCase("A#", new[] {"A#", "C#5", "D#5", "D##5", "E#5", "G#5"})]
        [TestCase("Bb", new[] {"Bb", "Db5", "Eb5", "E5", "F5", "Ab5"})]
        [TestCase("B", new[] {"B", "D5", "E5", "E#5", "F#5", "A5"})]
        [TestCase("B#", new[] {"B#", "D#5", "E#5", "E##5", "F##5", "A#5"})]
        public static void MinorBlues(string tonic, string[] expected)
        {
            TestNotes(tonic, expected, Scale.MinorBlues);
        }

        [Test]
        public static void AscendingNotes()
        {
            Assert.AreEqual(
                new [] {"C", "D", "E", "F", "G", "A", "B"}.Select(Note.Parse),
                Scale.Major(Note.Parse("C")).AscendingNotes
            );
        }

        [Test]
        public static void DescendingNotes()
        {
            Assert.AreEqual(
                new [] {"B", "A", "G", "F", "E", "D", "C"}.Select(Note.Parse),
                Scale.Major(Note.Parse("C")).DescendingNotes
            );
        }

        private static void TestNotes(
            string tonic, string[] expected, Func<Note, Scale> ctor, Direction? direction = null)
        {
            var scale = ctor(Note.Parse(tonic));
            var notes = (direction == Direction.Descending ? scale.DescendingNotes : scale.AscendingNotes).ToArray();

            Assert.AreEqual(expected.Length, scale.Length);

            for (var i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(Note.Parse(expected[i]), notes[i]);
            }
        }
    }
}
