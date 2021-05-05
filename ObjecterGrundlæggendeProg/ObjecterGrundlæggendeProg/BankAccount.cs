using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ObjecterGrundlæggendeProg
{
    public class BankAccount
    {
        private static decimal balance = 400;

        public static void Withdraw()
        {
            Console.WriteLine("Input Wanted Amount for Withdrawl");
            string userinput = Console.ReadLine();
            decimal withdrawl = Convert.ToDecimal(userinput);
            if (withdrawl < 0)
            {
                withdrawl = withdrawl * -1;
            }
            if (withdrawl <= balance)
            {
                Console.WriteLine("You Withdrew" + " " + withdrawl);
            }
            else
            {
                Console.WriteLine("You cannot do that");
            }
        }

        public static void Deposit()
        {
            Console.WriteLine("Input Wanted Amount for Deposit");
            string userinput = Console.ReadLine();
            decimal deposit = Convert.ToDecimal(userinput);
            balance = balance + deposit;
            Console.WriteLine("Deposited" + " " + deposit);
        }
    }
}
