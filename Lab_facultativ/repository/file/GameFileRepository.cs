namespace Lab_facultativ.repository.file;

public class GameFileRepository : AbstractFileRepository<Tuple<Tuple<int, int>, DateTime>, Game>
{
    public GameFileRepository(string filename) : base(filename)
    {
    }

    public override Game extractEntity(string line)
    {
        string[] fields = line.Split(',');
        Game meci = new Game();
        meci.id = new Tuple<Tuple<int, int>, DateTime>(
            new Tuple<int, int>(Convert.ToInt32(fields[0]), Convert.ToInt32(fields[1])),
            Convert.ToDateTime(fields[2]));
        return meci;
    }
}