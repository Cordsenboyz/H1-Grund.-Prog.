using System;
using System.IO;

namespace ObjecterGrundlæggendeProg
{
    class Program : BankAccount
    {

        static void Main(string[] args)
        {

            using (StreamWriter w = File.AppendText("log.txt"))
            {
                Log("Test1", w);
            }
            Console.WriteLine("Choose what you want to do. Withdraw -- 1 Or Deposit -- 2");
            string userinput = Console.ReadLine();
            switch(userinput)
            {
                case "1":
                    Withdraw();
                    break;
                case "2":
                    Deposit();
                    break;
                default:
                    Console.WriteLine("Wrong Input");
                    break;
            }
                    Console.ReadKey();
        }
        public static void Log(string logMessage, TextWriter w)
        {

        }
    }
}
