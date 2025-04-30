using BankingSystem;

public abstract class BankAccount : ITransaction
{
    protected string accountNumber;
    protected string accountHolderName;
    protected double balance;

    public BankAccount(string accountNumber, string accountHolderName, double balance)
    {
        this.accountNumber = accountNumber;
        this.accountHolderName = accountHolderName;
        this.balance = balance;
    }

    public abstract void CalculateInterest();

    public virtual void Deposit(double amount)
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

    public virtual void Withdraw(double amount)
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

public class SavingsAccount : BankAccount
{
    private double interestRate;

    public SavingsAccount(string accountNumber, string accountHolderName, double balance, double interestRate)
        : base(accountNumber, accountHolderName, balance)
    {
        this.interestRate = interestRate;
    }
    public override void CalculateInterest()
    {
        double interest = balance * interestRate / 100;
        Console.WriteLine($"Interest for account {accountNumber} is {interest}");
    }
    public void AddInterest()
    {
        double interest = balance * interestRate / 100;
        balance += interest;
        Console.WriteLine($"Interest ₹{interest} added.");
    }
    public override void Withdraw(double amount)
    {
        double minimumBalance = 1000; // Minimum balance requirement
        if (balance - amount >= minimumBalance)
        {
            base.Withdraw(amount);
        }
        else
        {
            Console.WriteLine("Withdrawal denied. Minimum balance requirement not met.");
        }
    }
}
public class CurrentAccount : BankAccount
{
    private double overdraftLimit;
    public CurrentAccount(string accountNumber, string accountHolderName, double balance, double overdraftLimit)
    : base(accountNumber, accountHolderName, balance)
    {
        this.overdraftLimit = overdraftLimit;
    }
    public override void CalculateInterest()
    {
        Console.WriteLine("Current accounts do not earn interest.");
    }
    public override void Withdraw(double amount)
    {
        if (amount <= balance + overdraftLimit)
        {
            balance -= amount;
            Console.WriteLine($"{amount} withdrawn from current account (Overdraft Allowed)");
        }
        else
        {
            Console.WriteLine("Withdrawal denied. Overdraft limit exceeded.");
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        // Create accounts using base class reference (Polymorphism)
        BankAccount savings = new SavingsAccount("SAV123", "Tamana Zehra", 5000, 4.5);
        BankAccount current = new CurrentAccount("CUR456", "Rahul Sharma", 3000, 2000);

        Console.WriteLine("\n=== Savings Account Operations ===");
        savings.Deposit(2000);                   // ITransaction
        savings.Withdraw(1000);                  // Overridden in SavingsAccount
        savings.CalculateInterest();             // Abstract method implementation
        savings.GetDetails();                // Shared from base class

        Console.WriteLine("\n=== Current Account Operations ===");
        current.Deposit(1000);                   // ITransaction
        current.Withdraw(4500);                  // Uses overdraft
        current.CalculateInterest();             // Shows no interest
        current.GetDetails();                // Shared from base class

        Console.WriteLine("\n=== Accessing via Interface ===");
        ITransaction transaction1 = savings;
        ITransaction transaction2 = current;

        transaction1.Deposit(500);
        transaction2.Withdraw(100);

        Console.WriteLine("\n--- Final Balances ---");
        Console.WriteLine($"Savings: {savings.GetBalance()}");
        Console.WriteLine($"Current: {current.GetBalance()}");
    }
}






