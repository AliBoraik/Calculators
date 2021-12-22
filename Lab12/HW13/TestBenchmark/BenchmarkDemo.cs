using System;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace TestBenchmark
{
    [ShortRunJob]
    [MinColumn]
    [MaxColumn]
    [MeanColumn]
    [MedianColumn]
    [MemoryDiagnoser]
    [MarkdownExporter]
    public class BenchmarkDemo
    {
        private readonly MethodsContainer _c;

        public BenchmarkDemo()
        {
            _c = new MethodsContainer();
        }

        [Benchmark]
        public int Static()
        {
            return MethodsContainer.StaticMethod(1);
        }

        [Benchmark]
        public int Virtual()
        {
            return _c.VirtualMethod(1);
        }

        [Benchmark]
        public int Generic()
        {
            return _c.GenericMethod<int>(1);
        }

        [Benchmark]
        public async Task<int> VirtualAsync()
        {
            return await _c.VirtualAsyncMethod(1);
        }

        [Benchmark]
        public async Task<int> StaticAsync()
        {
            return await MethodsContainer.StaticAsyncMethod(1);
        }

        [Benchmark]
        public int Dynamic()
        {
            return _c.DynamicMethod(1);
        }

        [Benchmark]
        public int Reflection()
        {
            return _c.ReflectionMethod(1);
        }
    }

    public sealed class MethodsContainer
    {
        public static int StaticMethod(int arg)
        {
            return arg * 2;
        }

        public int DynamicMethod(dynamic arg)
        {
            return arg * 2;
        }

        public int ReflectionMethod(int arg)
        {
            return (int) typeof(MethodsContainer).GetMethod("StaticMethod")!.Invoke(default, new object[] {arg})!;
        }

        public int VirtualMethod(int arg)
        {
            return arg * 2;
        }

        public int GenericMethod<T>(T arg) where T : struct
        {
            return (int) Convert.ChangeType(arg, Type.GetTypeCode(typeof(T))) * 2;
        }

        public Task<int> VirtualAsyncMethod(int arg)
        {
            return Task.FromResult(arg * 2);
        }

        public static Task<int> StaticAsyncMethod(int arg)
        {
            return Task.FromResult(arg * 2);
        }
    }
}