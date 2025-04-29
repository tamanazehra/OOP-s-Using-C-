using System.Security.Cryptography.X509Certificates;

public interface IAnimals
{
    string GetInfo();
    string Speak();
}
public interface IEat 
{
    string Eat();
}

public abstract class Animal : IAnimals
{
    private string name;
    private int age;
    private string species;
    public Animal(string name, int age, string species)
    {
        this.name = name;
        this.age = age;
        this.species = species;
    }
    public string GetInfo()
    {
        return $"Name: {name}, Age: {age}, Species: {species}";
    }
    public abstract string Speak();
}

public class Dog : Animal, IEat
{
    public Dog(string name, int age, string species) : base(name, age, species) { }
    public override string Speak()
    {
        return "Woof!";
    }
    public string Eat()
    {
        return "Dog eats Kibble";
    }
}

public class Cat : Animal, IEat
{
    public Cat(string name, int age, string species) : base(name, age, species) { }
    public override string Speak()
    {
        return "Meow!";
    }
    public string Eat()
    {
        return "Cat eats Fish";
    }
}

public class Loin : Animal, IEat
{
    public Loin(string name, int age, string species) : base(name, age, species) { }
    public override string Speak()
    {
        return "Roar!";
    }
    public string Eat()
    {
        return "Loin eats Meat";
    }
}

public class Elephant : Animal, IEat
{
    public Elephant(string name, int age, string species) : base(name, age, species) { }
    public override string Speak()
    {
        return "Trumpet!";
    }
    public string Eat()
    {
        return "Elephant eats Grass";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>
        {
            new Dog("Buddy", 3, "Dog"),
            new Cat("Whiskers", 2, "Cat"),
            new Loin("Simba", 5, "Loin"),
            new Elephant("Dumbo", 10, "Elephant")
        };
        foreach (var animal in animals)
        {
            Console.WriteLine(animal.GetInfo());
            Console.WriteLine(animal.Speak());
            if (animal is IEat eatableAnimal)
            {
                Console.WriteLine(eatableAnimal.Eat());
            }
            Console.WriteLine();
        }
    }
}