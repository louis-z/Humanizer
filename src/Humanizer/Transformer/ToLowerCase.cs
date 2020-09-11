using System;
using System.Buffers;

namespace Humanizer
{
    internal class ToLowerCase : IStringTransformer
    {
        public string Transform(string input)
        {
            var inputSpan = input.AsSpan();
            char[] buffer = ArrayPool<char>.Shared.Rent(inputSpan.Length);

            try
            {
                for (var i = 0; i < input.Length; i++)
                    buffer[i] = char.ToLower(input[i]);
                return new string(buffer, 0, input.Length);
            }
            finally
            {
                ArrayPool<char>.Shared.Return(buffer);
            }
        }
    }
}
