using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using WebApplication;

namespace TestWebApp
{
    public class TestClientProvider
    {
        public HttpClient Client { get; }
        public TestClientProvider()
        {
            var er = new WebApplicationFactory<Startup>();
          //  var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            Client = er.CreateClient();
        }

       
    }
}