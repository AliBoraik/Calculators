namespace Calculator_MVC.Models
{
    public class Calculator
    {
        private decimal _numberOne;
        private decimal _numbersTwo;

        public string Process(string num1, string operation, string num2)
        {
            return operation switch
            {
                CalculatorConstants.Add => Add(num1, num2),
                CalculatorConstants.Subtract => Sub(num1, num2),
                CalculatorConstants.Multiply => Mult(num1, num2),
                CalculatorConstants.Divide => Div(num1, num2),
                _ => CalculatorConstants.UnknownError
            };
        }

        private string Add(string num1, string num2)
        {
            if (Check(num1, num2)) return CalculatorConstants.Result + decimal.Add(_numberOne, _numbersTwo);
            return CalculatorConstants.NotIntegerErrorMassage;
        }

        private string Sub(string num1, string num2)
        {
            if (Check(num1, num2)) return CalculatorConstants.Result + decimal.Subtract(_numberOne, _numbersTwo);
            return CalculatorConstants.NotIntegerErrorMassage;
        }

        private string Mult(string num1, string num2)
        {
            if (Check(num1, num2)) return CalculatorConstants.Result + decimal.Multiply(_numberOne, _numbersTwo);
            return CalculatorConstants.NotIntegerErrorMassage;
        }

        private string Div(string num1, string num2)
        {
            if (Check(num1, num2))
            {
                if (_numbersTwo != 0) return CalculatorConstants.Result + decimal.Divide(_numberOne, _numbersTwo);
                return CalculatorConstants.DivideByZero;
            }

            return CalculatorConstants.NotIntegerErrorMassage;
        }

        private bool Check(string num1, string num2)
        {
            return decimal.TryParse(num1, out _numberOne) && decimal.TryParse(num2, out _numbersTwo);
        }
    }
}