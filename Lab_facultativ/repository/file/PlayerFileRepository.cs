namespace Lab_facultativ.repository.file;

public class PlayerFileRepository : AbstractFileRepository<int, Player>
{
    public PlayerFileRepository(string filename) : base(filename)
    {
    }

    public override Player extractEntity(string line)
    {
        string[] fields = line.Split(',');
        Player player = new Player(fields[1],fields[2],Int32.Parse(fields[3]));
        player.id = Int32.Parse(fields[0]);
        return player;
    }
}