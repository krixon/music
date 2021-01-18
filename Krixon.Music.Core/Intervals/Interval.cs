using System;

namespace Krixon.Music.Core.Intervals
{
    public sealed class Interval : IEquatable<Interval>, IComparable<Interval>
    {
        public int SemitoneCount { get; }

        public Quality Quality { get; }
        public Number Number { get; }

        private Interval(int semitoneCount, Quality quality, Number number)
        {
            SemitoneCount = semitoneCount;
            Quality = quality;
            Number = number;
        }

        public static Interval Unison() => new(0, Quality.Perfect, Number.Unison);
        public static Interval AugmentedUnison() => new(1, Quality.Augmented, Number.Unison);

        public static Interval DiminishedSecond() => new(0, Quality.Diminished, Number.Second);
        public static Interval MinorSecond() => new(1, Quality.Minor, Number.Second);
        public static Interval MajorSecond() => new(2, Quality.Major, Number.Second);
        public static Interval AugmentedSecond() => new(3, Quality.Augmented, Number.Second);

        public static Interval DiminishedThird() => new(2, Quality.Diminished, Number.Third);
        public static Interval MinorThird() => new(3, Quality.Minor, Number.Third);
        public static Interval MajorThird() => new(4, Quality.Major, Number.Third);
        public static Interval AugmentedThird() => new(5, Quality.Augmented, Number.Third);

        public static Interval DiminishedFourth() => new(4, Quality.Diminished, Number.Fourth);
        public static Interval PerfectFourth() => new(5, Quality.Perfect, Number.Fourth);
        public static Interval AugmentedFourth() => new(6, Quality.Augmented, Number.Fourth);

        public static Interval DiminishedFifth() => new(6, Quality.Diminished, Number.Fifth);
        public static Interval PerfectFifth() => new(7, Quality.Perfect, Number.Fifth);
        public static Interval AugmentedFifth() => new(8, Quality.Augmented, Number.Fifth);

        public static Interval DiminishedSixth() => new(7, Quality.Diminished, Number.Sixth);
        public static Interval MinorSixth() => new(8, Quality.Minor, Number.Sixth);
        public static Interval MajorSixth() => new(9, Quality.Major, Number.Sixth);
        public static Interval AugmentedSixth() => new(10, Quality.Augmented, Number.Sixth);

        public static Interval DiminishedSeventh() => new(9, Quality.Diminished, Number.Seventh);
        public static Interval MinorSeventh() => new(10, Quality.Minor, Number.Seventh);
        public static Interval MajorSeventh() => new(11, Quality.Major, Number.Seventh);
        public static Interval AugmentedSeventh() => new(12, Quality.Augmented, Number.Seventh);

        public static Interval DiminishedOctave() => new(11, Quality.Diminished, Number.Octave);
        public static Interval Octave() => new(12, Quality.Perfect, Number.Octave);

        /// <summary>
        /// Creates a new interval based on a number of semitones.
        /// </summary>
        /// <param name="semitoneCount"></param>
        /// <param name="number">
        /// A hint as to which interval number is sought. This can be used to resolve ambiguities
        /// since multiple intervals share a semitone count. If a number is specified which does not make
        /// sense due to the semitone count, an exception is thrown.
        /// </param>
        /// <exception cref="InvalidHintException">If number is incompatible with semitoneCount</exception>
        public static Interval FromSemitoneCount(int semitoneCount, Number? number = null)
        {
            var position = semitoneCount % 12;

            // Ensure that Octave is used over Unison when spanning multiple octaves.
            if (position == 0 && semitoneCount > 11) position = 12;

            var interval = position switch
            {
                0 when number == Number.Second => DiminishedSecond(),
                0 => Unison(),
                1 when number == Number.Unison => AugmentedUnison(),
                1 => MinorSecond(),
                2 when number == Number.Third => DiminishedThird(),
                2 => MajorSecond(),
                3 when number == Number.Second => AugmentedSecond(),
                3 => MinorThird(),
                4 when number == Number.Fourth => DiminishedFourth(),
                4 => MajorThird(),
                5 when number == Number.Third => AugmentedThird(),
                5 => PerfectFourth(),
                6 when number == Number.Fourth => AugmentedFourth(),
                6 => DiminishedFifth(),
                7 when number == Number.Sixth => DiminishedSixth(),
                7 => PerfectFifth(),
                8 when number == Number.Fifth => AugmentedFifth(),
                8 => MinorSixth(),
                9 when number == Number.Seventh => DiminishedSeventh(),
                9 => MajorSixth(),
                10 when number == Number.Sixth => AugmentedSixth(),
                10 => MinorSeventh(),
                11 when number == Number.Octave => DiminishedOctave(),
                11 => MajorSeventh(),
                12 when number == Number.Seventh => AugmentedSeventh(),
                12 => Octave(),
                _ => throw new ArgumentOutOfRangeException(
                    nameof(semitoneCount), semitoneCount, "Invalid semitone count.")
            };

            if (number != null && interval.Number != number)
            {
                throw new InvalidHintException(
                    $"Hinted number `{number}` is incompatible with semitone count `{semitoneCount}`.",
                    nameof(number)
                );
            }

            return interval;
        }

        /// <summary>
        /// Adjust the interval by the specified number of semitones.
        /// </summary>
        /// <param name="semitones">
        /// The number of semitones. If positive, the interval will be augmented, otherwise it will be diminished.
        /// </param>
        /// <returns></returns>
        public Interval Adjust(int semitones)
        {
            if (semitones == 0) return this;

            return semitones < 0 ? Diminish(semitones) : Augment(semitones);
        }

        /// <summary>
        /// Diminish the interval by one semitone.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the interval cannot be diminished.</exception>
        public Interval Diminish()
        {
            if (Quality == Quality.Diminished || Number == Number.Unison && Quality == Quality.Perfect)
            {
                throw new InvalidOperationException($"Interval `{Quality} {Number}` cannot be diminished.");
            }

            return FromSemitoneCount(SemitoneCount - 1, Number);
        }

        /// <summary>
        /// Augment the interval by one semitone.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the interval cannot be augmented.</exception>
        public Interval Augment()
        {
            if (Quality == Quality.Augmented)
            {
                throw new InvalidOperationException($"Interval `{Quality} {Number}` cannot be augmented.");
            }

            return FromSemitoneCount(SemitoneCount + 1, Number);
        }

        public override string ToString()
        {
            return $"{base.ToString()}: {Quality} {Number} ({SemitoneCount}st)";
        }

        public bool Equals(Interval? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return SemitoneCount == other.SemitoneCount && Quality == other.Quality && Number == other.Number;
        }

        public override bool Equals(object? obj)
        {
            return ReferenceEquals(this, obj) || obj is Interval other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SemitoneCount, (int) Quality, (int) Number);
        }

        public int CompareTo(Interval? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;

            var numberComparison = Number.CompareTo(other.Number);
            if (numberComparison != 0) return numberComparison;

            return (SemitoneCount % 12).CompareTo(other.SemitoneCount % 12);
        }

        /// <summary>
        /// Diminish the interval by a specified number of semitones.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the interval cannot be diminished.</exception>
        private Interval Diminish(int semitones)
        {
            var interval = this;

            while (semitones++ < 0) interval = interval.Diminish();

            return interval;
        }

        /// <summary>
        /// Augment the interval by a specified number of semitones.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the interval cannot be augmented.</exception>
        private Interval Augment(int semitones)
        {
            var interval = (Interval) MemberwiseClone();

            while (semitones-- > 0) interval = interval.Augment();

            return interval;
        }
    }
}
