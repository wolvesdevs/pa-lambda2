namespace Lambda2.Domain.Helper;

public class SaleItem(int saleId, int no, int productId, int saleCount)
{
    public int SaleId { get; } = saleId;
    public int No { get; } = no;
    public int ProductId { get; } = productId;
    public int SaleCount { get; } = saleCount;
}
