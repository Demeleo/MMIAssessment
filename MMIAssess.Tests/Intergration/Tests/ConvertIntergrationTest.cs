using MMIAssess.Core.Exceptions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace MMIAssess.Tests.Intergration.Tests
{
    public class ConvertIntergrationTest
    {
        [Theory]
        [InlineData("Temperature", "Celsius", "Kelvin", 200)]
        public async Task TestConvertEndpointSuccess(string type, string from, string to, decimal value)
        {
            var httpClient = new IntergrationTestProvider().Client;

            var response = await httpClient.GetAsync($"api/convert/{type}/{from}/{to}/{value}");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("Temperature", "mph", "Kelvin", 200)]
        public async Task TestConvertEndpointIncompatible(string type, string from, string to, decimal value)
        {
            var httpClient = new IntergrationTestProvider().Client;

            var response = await Record.ExceptionAsync(() => httpClient.GetAsync($"api/convert/{type}/{from}/{to}/{value}"));

            Assert.Equal(typeof(IncompatibleConversionException), response.GetType());
        }
    }
}
