namespace Lab_facultativ;

public class Team : Entity<int>
{
    public String name { get; set; }

    public Team(string name)
    {
        this.name = name;
    }

    public override string ToString()
    {
        return base.ToString() + "," + name;
    }
}