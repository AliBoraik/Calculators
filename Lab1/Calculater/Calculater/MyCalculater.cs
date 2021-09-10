using System;
using System.Numerics;

namespace Calculater
{
    class MyCalculater
    {
        public MyCalculater()
        {
            // I'm using class BigInterger to get result without errors
            // (:
        }


        public BigInteger add(string s1, string s2)
        {
            return BigInteger.Add(BigInteger.Parse(s1), BigInteger.Parse(s2));
        }
        public BigInteger Subtract(string s1, string s2)
        {
            return BigInteger.Subtract(BigInteger.Parse(s1), BigInteger.Parse(s2));
        }
        public BigInteger Multiply(string s1, string s2)
        {
            return BigInteger.Multiply(BigInteger.Parse(s1), BigInteger.Parse(s2));
        }
        public BigInteger Divide(string s1, string s2)
        {
            return BigInteger.Divide(BigInteger.Parse(s1), BigInteger.Parse(s2));
        }


        public bool isNumbers(string n1, string n2)
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
                    Console.WriteLine("The second orgument is not number!!");
                }
            }
            else
            {
                Console.WriteLine("The first orgument is not number!!");
            }
            return false;
        }
        public void proces(string n1, string oper, string n2)
        {
            var number_1 = n1;
            var number_2 = n2;
            switch (oper)
            {
                case "+":
                    Console.WriteLine(add(number_1, number_2).ToString());
                    break;
                case "-":
                    Console.WriteLine(Subtract(number_1, number_2).ToString());
                    break;
                case "*":
                    Console.WriteLine(Multiply(number_1, number_2).ToString());
                    break;
                case "/":
                    Console.WriteLine(Divide(number_1, number_2).ToString());
                    break;

                default:
                    Console.WriteLine("operation is not correct!!");
                    break;
            }
        }

    }
}
