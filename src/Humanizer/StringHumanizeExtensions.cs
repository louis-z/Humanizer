using System;
using System.Buffers;
using System.Linq;
using System.Text.RegularExpressions;

namespace Humanizer
{
    /// <summary>
    /// Contains extension methods for humanizing string values.
    /// </summary>
    public static class StringHumanizeExtensions
    {
        private static readonly Regex PascalCaseWordPartsRegex;

        static StringHumanizeExtensions()
        {
            PascalCaseWordPartsRegex = new Regex(@"[\p{Lu}]?[\p{Ll}]+|[0-9]+[\p{Ll}]*|[\p{Lu}]+(?=[\p{Lu}][\p{Ll}]|[0-9]|\b)|[\p{Lo}]+",
                RegexOptions.IgnorePatternWhitespace | RegexOptions.ExplicitCapture | RegexOptionsUtil.Compiled);
        }

        private static string FromUnderscoreDashSeparatedWords(ReadOnlySpan<char> input)
        {
            var buffer = ArrayPool<char>.Shared.Rent(input.Length);
            try
            {
                for (var i = 0; i < input.Length; i++)
                    buffer[i] = (input[i] == '_' || input[i] == '-') ? ' ' : input[i];
                return new string(buffer, 0, input.Length);
            }
            finally
            {
                ArrayPool<char>.Shared.Return(buffer);
            }
        }

        private static string FromPascalCase(string input)
        {
            var index = 0;
            var buffer = ArrayPool<char>.Shared.Rent(input.Length * 2);
            var bufferSpan = buffer.AsSpan();
            var inputSpan = input.AsSpan();

            foreach (Match match in PascalCaseWordPartsRegex.Matches(input))
            {
                var subSpan = bufferSpan.Slice(index);
                var slice = inputSpan.Slice(match.Index, match.Length);
                if (IsAllUpper(slice) && (match.Length > 1 || (match.Index > 0 && inputSpan[match.Index - 1] == ' ') || match.Value == "I"))
                    slice.CopyTo(subSpan);
                else
                    CopyToLower(slice, subSpan);
                subSpan[slice.Length] = ' ';
                index += slice.Length + 1;
            }

            string result;
            if (index > 0)
            {
                bufferSpan[0] = char.ToUpper(bufferSpan[0]);
                result = new string(buffer, 0, index - 1);
            }
            else
            {
                result = string.Empty;
            }

            ArrayPool<char>.Shared.Return(buffer);
            return result;
        }

        private static bool IsAllUpper(ReadOnlySpan<char> input)
        {
            for (var i = 0; i < input.Length; i++)
                if (!char.IsUpper(input[i]))
                    return false;
            return true;
        }

        private static bool IsFreestandingSpacing(ReadOnlySpan<char> input)
        {
            for (var i = 0; i < input.Length; i++)
                if (input[i] == '_' || input[i] == '-')
                    if ((i > 0 && input[i - 1] == ' ') || (i < input.Length - 1 && input[i + 1] == ' '))
                        return true;
            return false;
        }

        private static void CopyToLower(ReadOnlySpan<char> source, Span<char> target)
        {
            for (var i = 0; i < source.Length; i++)
                target[i] = char.ToLower(source[i]);
        }

        /// <summary>
        /// Humanizes the input string; e.g. Underscored_input_String_is_turned_INTO_sentence -> 'Underscored input String is turned INTO sentence'
        /// </summary>
        /// <param name="input">The string to be humanized</param>
        /// <returns></returns>
        public static string Humanize(this string input)
        {
            var inputSpan = input.AsSpan();

            // if input is all capitals (e.g. an acronym) then return it without change
            if (IsAllUpper(inputSpan))
            {
                return input;
            }

            // if input contains a dash or underscore which preceeds or follows a space (or both, e.g. free-standing)
            // remove the dash/underscore and run it through FromPascalCase
            if (IsFreestandingSpacing(inputSpan))
            {
                return FromPascalCase(FromUnderscoreDashSeparatedWords(inputSpan));
            }

            if (input.Contains("_") || input.Contains("-"))
            {
                return FromUnderscoreDashSeparatedWords(inputSpan);
            }

            return FromPascalCase(input);
        }

        /// <summary>
        /// Humanized the input string based on the provided casing
        /// </summary>
        /// <param name="input">The string to be humanized</param>
        /// <param name="casing">The desired casing for the output</param>
        /// <returns></returns>
        public static string Humanize(this string input, LetterCasing casing)
        {
            return input.Humanize().ApplyCase(casing);
        }
    }
}
