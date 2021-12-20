using BenchmarkDotNet.Running;

namespace TestBenchmark
{
    internal class Program
    {
        private static void Main()
        {
            BenchmarkRunner.Run<BenchmarkDemo>();
        }
    }
}