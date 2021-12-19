namespace Calculator_MVC.Middleware
{
    public interface ICalculator
    {
        string Process(string num1, string operation, string num2);
    }
}