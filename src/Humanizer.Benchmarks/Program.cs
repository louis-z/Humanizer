using System;
using BenchmarkDotNet.Running;

namespace HumanizerBenchmarks
{
    internal static class Program
    {
        private static void Main()
        {
#if DEBUG
            Console.WriteLine("*** Humanizing ***");
            Console.WriteLine(SpanBenchmarks.TextToHumanize);

            var spanBenchmarks = new SpanBenchmarks();
            var localHumanizedStr = spanBenchmarks.LocalHumanize();
            var nuGetHumanizedStr = spanBenchmarks.NuGetHumanize();

            if (localHumanizedStr.Equals(nuGetHumanizedStr, StringComparison.Ordinal))
            {
                Console.WriteLine();
                Console.WriteLine("*** Yields ***");
                Console.WriteLine();
                Console.WriteLine(localHumanizedStr);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("*** Using Local code ***");
                Console.WriteLine();
                Console.WriteLine(localHumanizedStr);

                Console.WriteLine();
                Console.WriteLine("*** Using NuGet package ***");
                Console.WriteLine();
                Console.WriteLine(nuGetHumanizedStr);
            }
#else
            BenchmarkRunner.Run<SpanBenchmarks>();
#endif
        }
    }
}
