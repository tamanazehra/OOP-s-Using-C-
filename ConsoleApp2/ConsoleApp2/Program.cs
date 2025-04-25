public class Grade
{
    protected int Marks;

    public void setMarks(int m)
    {
        if (m <= 100 && m >= 0)
        {
            Marks = m;
        }
        else
        {
            Console.WriteLine("Invalid Marks");
        }
    }
    public int getMarks()
    {
        return Marks;
    }
    public void displayGrade()
    {
        if (Marks >= 90)
        {
            Console.WriteLine("Grade A");
        }
        else if (Marks >= 80)
        {
            Console.WriteLine("Grade B");
        }
        else if (Marks >= 70)
        {
            Console.WriteLine("Grade C");
        }
        else if (Marks >= 60)
        {
            Console.WriteLine("Grade D");
        }
        else
        {
            Console.WriteLine("Invalid Marks");
        }
    }
}

public class Student : Grade
{
    public string Name;
    public void setName(string n)
    {
        Name = n;
    }
    public string getName()
    {
        return Name;
    }

}

public class Program
{
    static void Main(string[] args)
    {
        Student s = new Student();
        s.setName("John");
        s.setMarks(101);
        Console.WriteLine( s.Name + "'s" + " score is: " + s.getMarks());
        s.displayGrade();
    }
}
