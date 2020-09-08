using System;
using System.Linq;
using System.Text;

namespace Humanizer
{
    /// <summary>
    /// Contains extension methods for dehumanizing strings.
    /// </summary>
    public static class StringDehumanizeExtensions
    {
        /// <summary>
        /// Dehumanizes a string; e.g. 'some string', 'Some String', 'Some string' -> 'SomeString'
        /// </summary>
        /// <param name="input">The string to be dehumanized</param>
        /// <returns></returns>
        public static string Dehumanize(this string input)
        {
            var strBuilder = new StringBuilder();
            var span = input.AsSpan();
            var wordEnumerator = new WordEnumerator(span);

            foreach (var word in wordEnumerator)
            {
                strBuilder.Append(word.ToString().Humanize(LetterCasing.Title));
            }

            return strBuilder.ToString().Replace(" ", "");
        }
    }
}
