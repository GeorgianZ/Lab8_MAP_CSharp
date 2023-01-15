namespace Lab_facultativ.repository.file;

public class ActivePlayerFileRepository : AbstractFileRepository<Tuple<int, Tuple<Tuple<int, int>, DateTime>>, ActivePlayer>
{
    public ActivePlayerFileRepository(string filename) : base(filename)
    {
    }

    public override ActivePlayer extractEntity(string line)
    {
        string[] fields = line.Split(',');
        ActivePlayer activePlayer =
            new ActivePlayer(Convert.ToInt32(fields[4]), (Type)Enum.Parse(typeof(Type), fields[5]));
        activePlayer.id = new Tuple<int, Tuple<Tuple<int, int>, DateTime>>(Convert.ToInt32(fields[0]),
            new Tuple<Tuple<int, int>, DateTime>(
                new Tuple<int, int>(Convert.ToInt32(fields[1]), Convert.ToInt32(fields[2])),
                Convert.ToDateTime(fields[3])));
        return activePlayer;
    }
}