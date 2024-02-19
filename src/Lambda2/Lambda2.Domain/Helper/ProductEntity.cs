using System.Xml.Linq;

namespace Lambda2.Domain.Helper;

public sealed class ProductEntity
{
    public string Id { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return $"entity Id: {Id} Name: {Name}";
    }
}
