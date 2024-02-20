namespace Lambda2.Domain.Helper;

public class Sale(int saleId, int no, int customerId, DateTime saleDateTime)
{
    public int SaleId { get; } = saleId;
    public int No { get; } = no;
    public int CustomerId { get; } = customerId;
    public DateTime SaleDateTime { get; } = saleDateTime;
}
