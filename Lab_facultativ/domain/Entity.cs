namespace Lab_facultativ;

public class Entity<ID>
{

    public ID id { get; set; }

    public override string ToString()
    {
        return id.ToString();
    }
}