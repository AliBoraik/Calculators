using System.Net;
using System.Threading.Tasks;
using CalculatorF;
using TestWebApp;
using Xunit;

namespace TestCalculatorWebApp
{
    public class UnitTest1
    {
        [Fact]
        public async Task TestIndex_Page_ReturnOk()
        {
            var client = new TestClientProvider().Client;
            var response = await client.GetAsync("/");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TestNotFound_Page_ReturnNOtFound()
        {
            var client = new TestClientProvider().Client;
            var response = await client.GetAsync("/nullnull");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Theory]
        [InlineData("4,4", CalculatorConstants.Addition, "4,4", "Result = 8,8")]
        [InlineData("1212", CalculatorConstants.Addition, "2121", "Result = 3333")]
        [InlineData("4,4", CalculatorConstants.Subtract, "4,4", "Result = 0")]
        [InlineData("2", CalculatorConstants.Multiply, "2", "Result = 4")]
        [InlineData("4", CalculatorConstants.Divide, "2", "Result = 2")]
        public async Task TestResult_Page_ReturnNOtFound(string n1, string oper, string n2, string result)
        {
            var client = new TestClientProvider().Client;
            var response = await client.GetAsync($"/process?n1={n1}&n2={n2}&opre={oper}");

            var content_result = response.Content.ReadAsStringAsync().Result;
            Assert.Equal(content_result, result);
        }
    }
}