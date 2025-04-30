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
    public string GetAccountNumber() => accountNumber;

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








