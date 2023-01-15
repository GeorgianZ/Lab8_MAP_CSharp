namespace Lab_facultativ.repository.file;

public class TeamFileRepository : AbstractFileRepository<int, Team>
{
    public TeamFileRepository(string filename) : base(filename)
    {
    }
    
    public override Team extractEntity(string line)
    {
        string[] fields = line.Split(',');
        Team team = new Team(fields[1]);
        team.id = Int32.Parse(fields[0]);
        return team;
    }
}