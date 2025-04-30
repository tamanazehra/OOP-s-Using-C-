public class BankAccount
{
    protected string accountNumber; // Changed from private to protected  
    protected string accountHolderName;
    protected double balance;

    public BankAccount(string accountNumber, string accountHolderName, double balance)
    {
        this.accountNumber = accountNumber;
        this.accountHolderName = accountHolderName;
        this.balance = balance;
    }

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
    public void AddInterest()
    {
        double interest = balance * interestRate / 100;
        balance += interest;
        Console.WriteLine($"Interest ₹{interest} added to savings account.");
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
        // Savings Account Test
        SavingsAccount savings = new SavingsAccount("SAV001", "Tamana Zehra", 5000, 5);
        savings.GetDetails();
        savings.Deposit(2000);
        savings.AddInterest();
        savings.Withdraw(3500);
        Console.WriteLine($"Balance after interest: {savings.GetBalance()}\n");

        // Current Account Test
        CurrentAccount current = new CurrentAccount("CUR001", "Rahul Sharma", 3000, 2000);
        current.GetDetails();
        current.Withdraw(4500); // Overdraft used
        Console.WriteLine($"Balance after withdrawal: {current.GetBalance()}");
    }
}



