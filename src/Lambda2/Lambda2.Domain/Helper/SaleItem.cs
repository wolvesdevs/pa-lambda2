namespace Lambda2.Domain.Helper;

public class SaleItem(int saleId, int productId, int saleCount)
{
    public int SaleId { get; set; } = saleId;
    public int ProductId { get; set; } = productId;
    public int SaleCount { get; set; } = saleCount;
}
