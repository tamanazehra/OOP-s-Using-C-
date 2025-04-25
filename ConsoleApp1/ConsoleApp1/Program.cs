public class Dog
{
    public string Name;
    public void bark()
    {
        Console.WriteLine(Name + " says Woof!");
        Console.ReadLine();
    }
}

public class Car
{
    public string Model;
    public void honk()
    {
        Console.WriteLine(Model + " says Beep!");
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
    }




}
