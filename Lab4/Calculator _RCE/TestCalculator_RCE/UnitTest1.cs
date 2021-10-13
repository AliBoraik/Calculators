using CalculatorF;
using Xunit;

namespace TestCalculator_RCE
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("$", "+", "4", CalculatorConstants.NumbersErrorCode)]
        [InlineData("12", "-", "*", CalculatorConstants.NumbersErrorCode)]
        [InlineData("14", "yy", "4,5", CalculatorConstants.OperationErrorCode)]
        [InlineData("14", " ", "4,5", CalculatorConstants.OperationErrorCode)]
        [InlineData("14", " ", "4,5456", CalculatorConstants.OperationErrorCode)]
        public void TestMain_Method_ReturnErrorValue(string n1, string operation, string n2, int result)
        {
            var res = MyCalculator.getCodeForReturn(n1, operation, n2);

            Assert.Equal(res.ErrorValue, result);
        }

        [Theory]
        [InlineData("0.54324", "+", "4", CalculatorConstants.Ok_Code)]
        [InlineData("121212", "-", "12.1212", CalculatorConstants.Ok_Code)]
        [InlineData("12.12", "*", "4,5", CalculatorConstants.Ok_Code)]
        [InlineData("123", "-", "123", CalculatorConstants.Ok_Code)]
        [InlineData("14", "/", "4,5456", CalculatorConstants.Ok_Code)]
        public void TestMain_Method_ReturnValue(string n1, string operation, string n2, int result)
        {
            var res = MyCalculator.getCodeForReturn(n1, operation, n2);

            Assert.Equal(res.ResultValue, result);
        }


        [Theory]
        [InlineData("2", "+", "4", CalculatorConstants.Ok_Code)]
        [InlineData("12", "-", "4", CalculatorConstants.Ok_Code)]
        [InlineData("14", "-", "4,5", CalculatorConstants.Ok_Code)]
        [InlineData("21", "/", "3", CalculatorConstants.Ok_Code)]
        public void TestProces_ProcesMethod_ReturnResult(string n1, string operation, string n2, int result)
        {
            var code = MyCalculator.Proces(n1, operation, n2);

            Assert.Equal(code, result);
        }

        [Theory]
        [InlineData("2", "2", CalculatorConstants.Ok_Code)]
        [InlineData("2", "12", CalculatorConstants.Ok_Code)]
        [InlineData("2", "1212", CalculatorConstants.Ok_Code)]
        public void TestClaculator_AddMethod_ReturnSum(string n1, string n2, int result)
        {
            var re = MyCalculator.Add(n1, n2);

            Assert.Equal(re, result);
        }
    }
}