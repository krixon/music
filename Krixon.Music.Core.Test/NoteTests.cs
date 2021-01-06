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
    }
}
