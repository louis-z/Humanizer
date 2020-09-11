using BenchmarkDotNet.Running;

namespace HumanizerBenchmarks
{
    internal static class Program
    {
        private static void Main()
        {
            BenchmarkRunner.Run<SpanBenchmarks>();
        }
    }
}
