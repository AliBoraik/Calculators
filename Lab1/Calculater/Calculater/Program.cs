using System;

namespace Calculater
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length == 3)
            {
                string numbver_1 ;
                string numbver_2 ;
                string operation ;

                MyCalculater myCalcuater = new MyCalculater();

                numbver_1 = args[0];
                operation = args[1];
                numbver_2 = args[2];

                if (myCalcuater.isNumbers(numbver_1, numbver_2))
                {
                    myCalcuater.proces(numbver_1, operation, numbver_2);
                }
            }
            else
            {
                Console.WriteLine("неверное количество аргументов");
            }
        }
    }
}
