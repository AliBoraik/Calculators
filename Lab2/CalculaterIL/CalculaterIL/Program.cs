using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace CalculaterIL
{
    public class  Program
    {
        public static int Main(string[] args)
        {
            if (args.Length == 3)
            {
                string numbver_1;
                string numbver_2;
                string operation;
                
                numbver_1 = args[0];
                operation = args[1];
                numbver_2 = args[2];

                if (IsNumbers(numbver_1, numbver_2))
                {
                    if (IsOperation(operation))
                    {
                        Console.WriteLine(Proces(numbver_1, operation, numbver_2));
                        return 0;
                    }
                }
            }
            else
            {
                Console.WriteLine("неверное количество аргументов");
            }
            return 1;
        }
        [MethodImpl(MethodImplOptions.ForwardRef)]
        private static extern bool IsOperation(string oper);
        
        [MethodImpl(MethodImplOptions.ForwardRef)]
        private static extern bool IsNumbers(string num1,string num2);
        
        [MethodImpl(MethodImplOptions.ForwardRef)]
        private static extern string Proces(string num1,string oper,string num2);
        
    }
}
