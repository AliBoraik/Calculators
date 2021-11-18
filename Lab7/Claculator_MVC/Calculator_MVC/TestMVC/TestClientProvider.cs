using System.Net.Http;
using Calculator_MVC;
using Microsoft.AspNetCore.Mvc.Testing;

namespace TestWebApp
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