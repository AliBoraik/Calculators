using System.Net.Http;
using BenchmarkDotNet.Attributes;
using Calculator_MVC;
using Microsoft.AspNetCore.Mvc.Testing;

namespace TestBenchmark
{
    [MinColumn]
    [MaxColumn]
    [MemoryDiagnoser]
    public class BenchmarkDemo
    {
        // Clients
        private readonly HttpClient _cClient;
        private readonly HttpClient _fClient;

        public BenchmarkDemo()
        {
            // set Clients
            _cClient = new WebApplicationFactory<Calculator_MVC.Startup>().CreateClient();
            _fClient = new WebApplicationFactory<WebApplication.Startup>().CreateClient();
        }

        [Benchmark]
        public void AddMethod_C()
        {
            _cClient
                .GetAsync("https://localhost:5001/Calculator/Result?num1=12&num2=12&opre=add")
                .GetAwaiter()
                .GetResult();
        }

        [Benchmark]
        public void AddMethod_F()
        {
            _fClient
                .GetAsync("https://localhost:44393/process?n1=12&n2=12&opre=add")
                .GetAwaiter()
                .GetResult();
        }

        [Benchmark]
        public void SubMethod_C()
        {
            _cClient
                .GetAsync("https://localhost:5001/Calculator/Result?num1=12&num2=12&opre=sub")
                .GetAwaiter()
                .GetResult();
        }

        [Benchmark]
        public void SubMethod_F()
        {
            _fClient
                .GetAsync("https://localhost:44393/process?n1=12&n2=12&opre=sub")
                .GetAwaiter()
                .GetResult();
        }

        [Benchmark]
        public void MultMethod_C()
        {
            _cClient
                .GetAsync("https://localhost:5001/Calculator/Result?num1=12&num2=12&opre=mul")
                .GetAwaiter()
                .GetResult();
        }

        [Benchmark]
        public void MultMethod_F()
        {
            _fClient
                .GetAsync("https://localhost:44393/process?n1=12&n2=12&opre=mul")
                .GetAwaiter()
                .GetResult();
        }
    }
}