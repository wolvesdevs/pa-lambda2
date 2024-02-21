namespace Lambda2.Domain.Helper;

public sealed class Product(int id, string name, int price)
{
    public int Id { get; } = id;
    public string Name { get; } = name;
    public int Price { get; } = price;

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        var product = obj as Product;
        if (product is null)
        {
            return false;
        }

        if(product.Id != Id)
        {
            return false;
        }

        if(product.Name != Name)
        {
            return false;
        }

        if(product.Price != Price)
        {
            return false;
        }

        return true;
    }
}
