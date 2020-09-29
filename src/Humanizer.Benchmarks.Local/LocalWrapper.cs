namespace Humanizer.Benchmarks.Local
{
    public static class LocalWrapper
    {
        public static string HumanizeStr(string str)
        {
            return str.Humanize();
        }
    }
}
