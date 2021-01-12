namespace Krixon.Music.Core.Interval
{
    public readonly struct Interval
    {
        public int SemitoneCount { get; }
        public Quality Quality { get; }
        public Number Number { get; }

        private Interval(int semitoneCount, Quality quality, Number number, int octaves = 0)
        {
            SemitoneCount = semitoneCount + 12 * octaves;
            Quality = quality;
            Number = number;
        }

        public static Interval Unison() => new(0, Quality.Perfect, Number.Unison);
        public static Interval MinorSecond() => new(1, Quality.Minor, Number.Second);
        public static Interval MajorSecond() => new(2, Quality.Major, Number.Second);
        public static Interval MinorThird() => new(3, Quality.Minor, Number.Third);
        public static Interval MajorThird() => new(4, Quality.Major, Number.Third);
        public static Interval PerfectFourth() => new(5, Quality.Perfect, Number.Fourth);
        public static Interval DiminishedFifth() => new(6, Quality.Diminished, Number.Fifth);
        public static Interval PerfectFifth() => new(7, Quality.Perfect, Number.Fifth);
        public static Interval MinorSixth() => new(8, Quality.Minor, Number.Sixth);
        public static Interval MajorSixth() => new(9, Quality.Major, Number.Sixth);
        public static Interval MinorSeventh() => new(10, Quality.Minor, Number.Seventh);
        public static Interval MajorSeventh() => new(11, Quality.Major, Number.Seventh);
        public static Interval Octave() => new (12, Quality.Perfect, Number.Octave);

        public override string ToString()
        {
            return $"{base.ToString()}: {Quality} {Number} ({SemitoneCount}st)";
        }
    }
}
