using System;
using Xunit;

namespace TestCalculator
{
    public class UnitTest1
    {

        [Theory]
        [InlineData("2", "+", "4","6")]
        [InlineData("12", "-", "4","8")]
        [InlineData("14", "*", "4","56")]
        [InlineData("21", "/", "3","7")]

        public void TestProces_ProcesMethod_ReturnResult(string n1,string operation, string n2, string result)
        {
            var calculater = new Calculater.MyCalculater();

            Assert.Equal(calculater.proces(n1,operation, n2), result);
        }

        [Theory]
        [InlineData("2","2","4")]
        [InlineData("2","12","14")]
        [InlineData("2","1212","1214")]
        [InlineData("22134567809876543","123456789876543", "22258024599753086")]
        public void TestClaculator_AddMethod_ReturnSum(string n1,string n2,string result)
        {
            var calculater = new Calculater.MyCalculater();

            Assert.Equal(calculater.add(n1, n2), result);
        }
        [Theory]
        [InlineData("2", "2", "0")]
        [InlineData("2", "12", "-10")]
        [InlineData("1212", "2", "1210")]
        [InlineData("22134567809876543", "123456789876543", "22011111020000000")]
        public void TestClaculator_SumMethod_ReturnSum(string n1, string n2, string result)
        {
            var calculater = new Calculater.MyCalculater();

            Assert.Equal(calculater.Subtract(n1, n2), result);
        }
        [Theory]
        [InlineData("2", "10", "20")]
        [InlineData("2", "12", "24")]
        [InlineData("2", "4", "8")]
        [InlineData("22134567809876543", "123456789876543", "2732662687112020956973041630849")]
        public void TestClaculator_MultiMethod_ReturMul(string n1, string n2, string result)
        {
            var calculater = new Calculater.MyCalculater();

            Assert.Equal(calculater.Multiply(n1, n2), result);
        }
        [Theory]
        [InlineData("2", "2", "1")]
        [InlineData("4", "2", "2")]
        [InlineData("1000", "2", "500")]
        [InlineData("22134567809876543", "123456789876543", "179")]
        public void TestClaculator_DivMethod_ReturnDiv(string n1, string n2, string result)
        {
            var calculater = new Calculater.MyCalculater();

            Assert.Equal(calculater.Divide(n1, n2), result);
        }

    }
}
