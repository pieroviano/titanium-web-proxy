#if !NETSTANDARD2_1_OR_GREATER && !NET5_0_OR_GREATER
namespace System
{
    /// <summary>
    ///     Position in a sequence, counted either from the start or from the end. The compiler needs
    ///     this type to exist to emit index-from-end (<c>^1</c>) and range (<c>a..b</c>) syntax; the
    ///     BCL only ships it from netstandard2.1 / .NET Core 3.0 on.
    /// </summary>
    internal readonly struct Index : global::System.IEquatable<Index>
    {
        // Counted from the start the value is stored as is; counted from the end it is stored
        // bitwise-complemented, so one int carries both the offset and the direction.
        private readonly int value;

        public Index(int value, bool fromEnd = false)
        {
            if (value < 0) throw new global::System.ArgumentOutOfRangeException(nameof(value), "Non-negative number required.");

            this.value = fromEnd ? ~value : value;
        }

        private Index(int value)
        {
            this.value = value;
        }

        public static Index Start => new Index(0);

        public static Index End => new Index(~0);

        public static Index FromStart(int value)
        {
            if (value < 0) throw new global::System.ArgumentOutOfRangeException(nameof(value), "Non-negative number required.");

            return new Index(value);
        }

        public static Index FromEnd(int value)
        {
            if (value < 0) throw new global::System.ArgumentOutOfRangeException(nameof(value), "Non-negative number required.");

            return new Index(~value);
        }

        public int Value => value < 0 ? ~value : value;

        public bool IsFromEnd => value < 0;

        /// <summary>Resolves this position against a sequence of <paramref name="length" /> elements.</summary>
        public int GetOffset(int length)
        {
            var offset = value;
            if (IsFromEnd) offset += length + 1;

            return offset;
        }

        public override bool Equals(object? obj)
        {
            return obj is Index other && other.value == value;
        }

        public bool Equals(Index other)
        {
            return other.value == value;
        }

        public override int GetHashCode()
        {
            return value;
        }

        public override string ToString()
        {
            return IsFromEnd ? "^" + ((uint)Value).ToString() : ((uint)Value).ToString();
        }

        public static implicit operator Index(int value)
        {
            return FromStart(value);
        }
    }

    /// <summary>
    ///     Range between a start and an end <see cref="Index" />. The compiler needs this type to
    ///     exist to emit range (<c>a..b</c>) syntax; the BCL only ships it from netstandard2.1 /
    ///     .NET Core 3.0 on.
    /// </summary>
    internal readonly struct Range : global::System.IEquatable<Range>
    {
        public Range(Index start, Index end)
        {
            Start = start;
            End = end;
        }

        public Index Start { get; }

        public Index End { get; }

        public static Range StartAt(Index start)
        {
            return new Range(start, Index.End);
        }

        public static Range EndAt(Index end)
        {
            return new Range(Index.Start, end);
        }

        public static Range All => new Range(Index.Start, Index.End);

        public override bool Equals(object? obj)
        {
            return obj is Range other && other.Start.Equals(Start) && other.End.Equals(End);
        }

        public bool Equals(Range other)
        {
            return other.Start.Equals(Start) && other.End.Equals(End);
        }

        public override int GetHashCode()
        {
            return (Start.GetHashCode() * 31) + End.GetHashCode();
        }

        public override string ToString()
        {
            return Start + ".." + End;
        }
    }
}
#endif
