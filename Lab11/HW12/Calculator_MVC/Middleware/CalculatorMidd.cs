using Calculator_MVC.Models;

namespace Calculator_MVC.Middleware
{
    public class CalculatorMidd : ICalculator
    {
        public string Process(string num1, string operation, string num2)
        {
            var calculator = new Calculator();

            return calculator.Process(num1, operation, num2);
        }
    }
}