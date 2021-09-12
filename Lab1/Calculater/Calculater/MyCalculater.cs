﻿using System;
using System.Numerics;

namespace Calculater
{
    public class MyCalculater
    {
        public MyCalculater()
        {
            // I'm using class BigInterger to get result without errors
            // (:
        }


        public string add(string s1, string s2)
        {
            return BigInteger.Add(BigInteger.Parse(s1), BigInteger.Parse(s2)).ToString();
        }
        public string Subtract(string s1, string s2)
        {
            return BigInteger.Subtract(BigInteger.Parse(s1), BigInteger.Parse(s2)).ToString();
        }

        internal static bool isOperation(string operation)
        {
            bool IsOperation ;
            IsOperation = operation switch
            {
                "+" => true,
                "-" => true,
                "*" => true,
                "/" => true,
                _ => false
            };
            if (!IsOperation)
            {
                Console.WriteLine("operation is not correct!!");
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
        public string proces(string n1, string oper, string n2)
        {
            var number_1 = n1;
            var number_2 = n2;
            switch (oper)
            {
                case "+":
                    return add(number_1, number_2);
                case "-":
                    return Subtract(number_1, number_2);
                case "*":
                    return Multiply(number_1, number_2);
                default:
                    return Divide(number_1, number_2);
            }
        }

    }
}