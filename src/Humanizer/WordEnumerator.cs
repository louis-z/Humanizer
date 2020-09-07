using System;
using System.Linq;

namespace Humanizer
{
    /// <summary>
    /// Word Enumerator that can be used in a foreach statement
    /// Must be a ref struct as it contains ReadOnlySpan field and property
    /// </summary>
    /// <remarks>
    /// Thanks to Meziantou, whose blog post inspired me:
    /// https://www.meziantou.net/split-a-string-into-lines-without-allocation.htm
    /// </remarks>
    internal ref struct WordEnumerator
    {
        private ReadOnlySpan<char> _remainingSpan;

        public WordEnumerator(ReadOnlySpan<char> strSpan)
        {
            _remainingSpan = strSpan;
            Current = default;
        }

        public ReadOnlySpan<char> Current { get; private set; } // For compatibility with foreach operator
        public WordEnumerator GetEnumerator() => this;          // For compatibility with foreach operator

        public bool MoveNext()
        {
            var span = _remainingSpan;
            if (span.Length == 0)
                return false;

            // Find the first space
            var indexStart = span.IndexOf(' ');
            if (indexStart == -1) // _remainingSpan contains a single word
            {
                _remainingSpan = ReadOnlySpan<char>.Empty;
                Current = span;
                return true;
            }

            // Find the end of the separator series
            var indexEnd = indexStart;
            while (indexEnd < span.Length - 1 && span[indexEnd + 1] == ' ')
            {
                indexEnd++;
            }

            _remainingSpan = span.Slice(indexEnd + 1);

            // If this is an empty word, get the next one immediately
            if (indexStart == 0)
                return MoveNext();

            Current = span.Slice(0, indexStart);
            return true;
        }
    }
}
