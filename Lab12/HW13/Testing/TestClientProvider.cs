using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using WebApplication;

namespace Testing
{
    public class TestClientProvider
    {
        public TestClientProvider()
        {
            var er = new WebApplicationFactory<Startup>();
            //  var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            Client = er.CreateClient();
        }

        public HttpClient Client { get; }
    }
}