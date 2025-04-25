public class Dog
{
    public string Name;
    public void bark()
    {
        Console.Write(Name + " says Woof!");
        Console.ReadLine();
    }
}

public class Car
{
    public string Model;
    public void honk()
    {
        Console.Write(Model + " says Beep!");
        Console.Read();
    }
}

public class person
{
    public string Name;
    public void greet()
    {
        Console.Write("Hello, my name is " + Name);
        Console.ReadLine();
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Dog dog = new Dog();
        dog.Name = "Buddy";
        dog.bark();

        Car car = new Car();
        car.Model = "Toyota";
        car.honk();

        person person = new person();
        person.Name = "Alice";
        person.greet();
    }
}
