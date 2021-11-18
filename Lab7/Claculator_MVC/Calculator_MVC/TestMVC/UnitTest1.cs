using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Calculator_MVC.Models;
using TestWebApp;
using Xunit;

namespace TestMVC
{
    public class UnitTest1
    {
        private static HttpClient client = new();

        [Fact]
        public async Task TestIndex_Page_ReturnOk()
        {
            var client = new TestClientProvider().Client;
            var response = await client.GetAsync("/Calculator");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("4,4", CalculatorConstants.Add, "4,4", "Result = 8,8")]
        [InlineData("1212", CalculatorConstants.Add, "2121", "Result = 3333")]
        [InlineData("4,4", CalculatorConstants.Subtract, "4,4", "Result = 0,0")]
        [InlineData("2", CalculatorConstants.Multiply, "2", "Result = 4")]
        [InlineData("4", CalculatorConstants.Divide, "2", "Result = 2")]
        [InlineData("@", CalculatorConstants.Multiply, "2", CalculatorConstants.NotIntegerErrorMassage)]
        [InlineData("4", CalculatorConstants.Divide, "0", CalculatorConstants.DivideByZero)]
        public async Task TestResult_Result_ReturnNOtFound(string n1, string oper, string n2, string result)
        {
            var calculatorResult = new Calculator().Process(n1, oper, n2);
            Assert.Equal(calculatorResult, result);
        }

        [Theory]
        [InlineData("4,4", CalculatorConstants.Add, "4,4", "Result = 8,8")]
        [InlineData("1212", CalculatorConstants.Add, "2121", "Result = 3333")]
        [InlineData("4,4", CalculatorConstants.Subtract, "4,4", "Result = 0,0")]
        [InlineData("2", CalculatorConstants.Multiply, "2", "Result = 4")]
        [InlineData("4", CalculatorConstants.Divide, "2", "Result = 2")]
        [InlineData("@", CalculatorConstants.Multiply, "2", CalculatorConstants.NotIntegerErrorMassage)]
        [InlineData("4", CalculatorConstants.Divide, "0", CalculatorConstants.DivideByZero)]
        public async Task TestResult_Page_ReturnNOtFound(string n1, string oper, string n2, string result)
        {
            var url = $"https://localhost:5001/Calculator/Result?num1={n1}&num2={n2}&opre={oper}";
            var client = new TestClientProvider().Client;

            var response = client.GetAsync(url).GetAwaiter().GetResult();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var resultFromServer = getResult(content);

            Assert.Equal(resultFromServer, result);
        }

        private string getResult(string content)
        {
            var s = content.IndexOf("* ", StringComparison.Ordinal) + 2;
            var t = content[s..];
            var e = t.IndexOf("</text>", StringComparison.Ordinal);
            return t.Substring(0, e);
        }
    }
}