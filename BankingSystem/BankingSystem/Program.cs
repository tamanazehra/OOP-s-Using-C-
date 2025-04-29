public class BankAccount
{
    private string accountNumber;
    private string accountHolderName;
    private double balance;

    public BankAccount(string accountNumber, string accountHolderName, double balance)
    {
        this.accountNumber = accountNumber;
        this.accountHolderName = accountHolderName;
        this.balance = balance;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"Deposited {amount} to account {accountNumber}. New balance is {balance}.");
        }
        else
        {
            Console.WriteLine("Invalid Deposit Amount.");
        }
    }
    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"Withdrew {amount} from account {accountNumber}. New balance is {balance}.");
        }
        else
        {
            Console.WriteLine("Invalid Withdraw Amount.");
        }

    }
    public double GetBalance()
    {
        return balance;
    }

    public void GetDetails()
    {
        Console.WriteLine($"Account Number: {accountNumber}");
        Console.WriteLine($"Account Holder Name: {accountHolderName}");
        Console.WriteLine($"Balance: {balance}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount("123456789", "John Doe", 1000.00);
        account.GetDetails();
        account.Deposit(500);
        account.Withdraw(200);
        Console.WriteLine($"Final Balance: {account.GetBalance()}");
    }
}
