namespace Lambda2.Domain.Helper;

public sealed class Product(int id, string name, int price)
{
    public int Id { get; } = id;
    public string Name { get; } = name;
    public int Price { get; } = price;
}
