public interface IAnimal
{
    string Speak();
}
public class Dog : IAnimal
{
    public string Speak()
    {
        return "Woof!";
    }
    
    public string name;
    public string GetName(string name)
    {
        return name;
    }

}
public class Cat : IAnimal
{
    public string Speak()
    {
        return "Meow!";
    }

    public string name;
    public string GetName(string name)
    {
        return name;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Dog dog1 = new Dog();
        dog1.name = "tommy";
        Console.WriteLine(dog1.name + " says " + dog1.Speak());
        
        Cat cat1 = new Cat();
        cat1.name = "kitty";
        Console.WriteLine(cat1.name + " says " + cat1.Speak());
    }
}

