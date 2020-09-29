namespace Humanizer.Benchmarks.NuGet
{
    public static class NuGetWrapper
    {
        public static string HumanizeStr(string str)
        {
            return str.Humanize();
        }
    }
}
