using System;
using System.Numerics;

namespace Calculater
{
    public class MyCalculater
    {
        public string Addition(string s1, string s2)
        {
            return BigInteger.Add(BigInteger.Parse(s1), BigInteger.Parse(s2)).ToString();
        }

        public string Subtract(string s1, string s2)
        {
            return BigInteger.Subtract(BigInteger.Parse(s1), BigInteger.Parse(s2)).ToString();
        }

        internal static bool IsOperation(string operation)
        {
            Console.WriteLine(CalculatorConstants.Add);
            bool IsOperation ;
            IsOperation = operation switch
            {
                CalculatorConstants.Add => true,
                CalculatorConstants.Subtract => true,
                CalculatorConstants.Multiply => true,
                CalculatorConstants.Divide => true,
                _ => false
            };
            if (!IsOperation)
            {
                Console.WriteLine(CalculatorConstants.OperationError);
            }
            return IsOperation;
        }

        public string Multiply(string s1, string s2)
        {
            return BigInteger.Multiply(BigInteger.Parse(s1), BigInteger.Parse(s2)).ToString();
        }

        public string Divide(string s1, string s2)
        {
            return BigInteger.Divide(BigInteger.Parse(s1), BigInteger.Parse(s2)).ToString();
        }

        public bool IsNumbers(string n1, string n2)
        {
            BigInteger number_1;
            if (BigInteger.TryParse(n1, out number_1))
            {
                if (BigInteger.TryParse(n2, out number_1))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine(CalculatorConstants.SecondArgumenError);
                }
            }
            else
            {
                Console.WriteLine(CalculatorConstants.FirstArgumenError);
            }
            return false;
        }

        public string Proces(string n1, string oper, string n2)
        {
            var number_1 = n1;
            var number_2 = n2;
            switch (oper)
            {
                case CalculatorConstants.Add:
                    return Addition(number_1, number_2);
                case CalculatorConstants.Subtract:
                    return Subtract(number_1, number_2);
                case CalculatorConstants.Multiply:
                    return Multiply(number_1, number_2);
                default:
                    return Divide(number_1, number_2);
            }
        }

    }
}
