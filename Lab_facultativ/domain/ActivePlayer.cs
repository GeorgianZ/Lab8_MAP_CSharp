namespace Lab_facultativ;

public enum Type
{
    Participant,
    Rezerva
}

public class ActivePlayer : Entity<Tuple<int, Tuple<Tuple<int, int>, DateTime>>>
{
    public int points { get; set; }
    public Type type { get; set; }

    public ActivePlayer(int points, Type type)
    {
        this.points = points;
        this.type = type;
    }

    public override string ToString()
    {
        return base.ToString() + "," + points + "," + type;
    }

    protected bool Equals(ActivePlayer other)
    {
        return points == other.points && type == other.type;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ActivePlayer)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(points, (int)type);
    }
}