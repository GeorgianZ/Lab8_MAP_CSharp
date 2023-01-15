namespace Lab_facultativ;

public class Student : Entity<int>
{
    public String name { get; set; }
    
    public String school { get; set; }

    public Student(string name, string school)
    {
        this.name = name;
        this.school = school;
    }

    public override string ToString()
    {
        return base.ToString() + "," + name + "," + school;
    }
}