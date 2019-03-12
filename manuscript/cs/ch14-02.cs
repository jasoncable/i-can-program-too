public class Category : IIdentifiable
{
    public Category() { }
    public Category(string name) : this()
    {
        Name = name;
    }
    public string Name { get; set; }
    public Guid Id { get; private set; } = new Guid();
    public override string ToString()
    {
        return $"Id: {Id} ~ Name: {Name}";
    }
}