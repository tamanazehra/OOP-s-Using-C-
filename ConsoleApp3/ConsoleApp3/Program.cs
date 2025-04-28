public interface IPayment
{
    string pay();
}

public class CreditCard : IPayment
{
    public string pay()
    {
        return "Paid with Credit Card";
    }
}

public class PayPal : IPayment
{
    public string pay()
    {
        return "Paid with PayPal";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Choose a Payment Method:");
        Console.WriteLine("1. Credit Card");
        Console.WriteLine("2. PayPal");
        Console.Write("Enter your choice (1 or 2): ");

        string choice = Console.ReadLine();
     


        IPayment payment;

        if (choice == "1")
        {
            payment = new CreditCard();
        }
        else if (choice == "2")
        {
            payment = new PayPal();
        }
        else
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        Console.WriteLine(payment.pay());


    }
}