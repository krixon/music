using NUnit.Framework;

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

        [Test]
        [TestCase("C0", 12, "C1")]
        [TestCase("C1", 12, "C2")]
        [TestCase("C2", 12, "C3")]
        [TestCase("C3", 12, "C4")]
        [TestCase("C4", 12, "C5")]
        [TestCase("C5", 12, "C6")]
        [TestCase("C6", 12, "C7")]
        [TestCase("C7", 12, "C8")]
        [TestCase("C8", 12, "C9")]
        [TestCase("C4", 1, "C#4")]
        [TestCase("C4", 2, "D4")]
        [TestCase("C4", 3, "D#4")]
        [TestCase("C4", 4, "E4")]
        [TestCase("C4", 5, "F4")]
        [TestCase("C4", 6, "F#4")]
        [TestCase("C4", 7, "G4")]
        [TestCase("C4", 8, "G#4")]
        [TestCase("C4", 9, "A4")]
        [TestCase("C4", 10, "A#4")]
        [TestCase("C4", 11, "B4")]
        [TestCase("C4", 12, "C5")]
        [TestCase("C4", 13, "C#5")]
        [TestCase("C0", 28, "E2")]
        public static void Transpose(string start, int semitones, string expected)
        {
            Assert.AreEqual(Note.Parse(expected), Note.Parse(start).Transpose(semitones));
        }
    }
}
