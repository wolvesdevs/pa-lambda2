namespace Lambda2.Domain.Helper;

public sealed class ProductDto(string id, string name)
{
    public ProductDto(Product product) : this(product.Id.ToString(), product.Name)
    {
    }

    public string Id { get; } = id;
    public string Name { get; } = name;

    public override string ToString()
    {
        return $"dto Id: {Id} Name: {Name}";
    }
}
