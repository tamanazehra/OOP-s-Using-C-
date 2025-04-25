public class student
{
    private int Marks;

    public void setGrade(int m)
    {
        if(m <= 100 && m >= 0)
        {
            Marks = m;
        } 
        else
        {
            Console.WriteLine("Invalid Marks");
        }
    }
    public int getGrade()
    {
        return Marks;
    }
}

public class Progarm
{
    static void Main(string[] args)
    {
        student s = new student();
        s.setGrade(10);
        Console.WriteLine("Student grade is: " + s.getGrade());
    }
}
