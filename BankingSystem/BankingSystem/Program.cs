using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    class Program
    {
        static List<BankAccount> accounts = new List<BankAccount>();
        private static int choice;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=== Banking System Menu ===");
                Console.WriteLine("1. Create Savings Account");
                Console.WriteLine("2. Create Current Account");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Withdraw");
                Console.WriteLine("5. Show Account Details");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateSavingsAccount();
                        break;
                    case 2:
                        CreateCurrentAccount();
                        break;
                    case 3:
                        PerformTransaction("deposit");
                        break;
                    case 4:
                        PerformTransaction("withdraw");
                        break;
                    case 5:
                        ShowDetails();
                        break;
                    case 6:
                        Console.WriteLine("Thank you for using the Banking System.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

    static void CreateSavingsAccount()
        {
            Console.Write("Enter Account Number: ");
            string accNo = Console.ReadLine();
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Initial Balance: ");
            double bal = double.Parse(Console.ReadLine());
            Console.Write("Enter Interest Rate: ");
            double rate = double.Parse(Console.ReadLine());

            accounts.Add(new SavingsAccount(accNo, name, bal, rate));
            Console.WriteLine("Savings account created successfully.");
        }

        static void CreateCurrentAccount()
        {
            Console.Write("Enter Account Number: ");
            string accNo = Console.ReadLine();
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Initial Balance: ");
            double bal = double.Parse(Console.ReadLine());
            Console.Write("Enter Overdraft Limit: ");
            double limit = double.Parse(Console.ReadLine());

            accounts.Add(new CurrentAccount(accNo, name, bal, limit));
            Console.WriteLine("Current account created successfully.");
        }

        static void PerformTransaction(string type)
        {
            Console.Write("Enter Account Number: ");
            string accNo = Console.ReadLine();

            BankAccount acc = accounts.Find(a => a.GetAccountNumber() == accNo);
            if (acc == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            Console.Write($"Enter amount to {type}: ");
            double amount = double.Parse(Console.ReadLine());

            if (type == "deposit") acc.Deposit(amount);
            else acc.Withdraw(amount);
        }

        static void ShowDetails()
        {
            Console.Write("Enter Account Number: ");
            string accNo = Console.ReadLine();

            BankAccount acc = accounts.Find(a => a.GetAccountNumber() == accNo);
            if (acc == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            acc.GetDetails();
        }
    }
}

    