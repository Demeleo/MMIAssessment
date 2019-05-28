using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using MMIAssess.API;
using System.Net.Http;

namespace MMIAssess.Tests.Intergration
{
    public class IntergrationTestProvider
    {
        public HttpClient Client { get; private set; }
        public IntergrationTestProvider()
        {
            var server = new TestServer(
                new WebHostBuilder().UseStartup<Startup>()
                );

            Client = server.CreateClient();
        }
    }
}
