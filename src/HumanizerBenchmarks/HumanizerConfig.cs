using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;

namespace HumanizerBenchmarks
{
    public class HumanizerConfig : ManualConfig
    {
        public HumanizerConfig()
        {
            var baseJob = Job.MediumRun;

            AddJob(baseJob.WithNuGet("Humanizer.Core", "2.8.99").WithId("2.8.99"));
            AddJob(baseJob.WithNuGet("Humanizer.Core", "2.8.26").WithId("2.8.26"));
        }
    }
}
