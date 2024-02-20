namespace Lambda2.Domain.Helper;

public class Sale(int saleId, int customerId, DateTime saleDateTime)
{
    public int SaleId { get; set; } = saleId;
    public int CustomerId { get; set; } = customerId;
    public DateTime SaleDateTime { get; set; } = saleDateTime;
}
