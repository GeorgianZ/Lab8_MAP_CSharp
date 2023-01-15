namespace Lab_facultativ;

public class Player : Student
{
    public int idTeam { get; set; }

    public Player(string name, string school, int idTeam) : base(name, school)
    {
        this.idTeam = idTeam;
    }

    public override string ToString()
    {
        return base.ToString() + "," + idTeam;
    }
}