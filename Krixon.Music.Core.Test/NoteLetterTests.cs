using NUnit.Framework;

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
    }
}
