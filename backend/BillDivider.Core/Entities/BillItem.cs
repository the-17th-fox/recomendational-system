namespace BillDivider.Core.Entities;

public class BillItem : BaseEntity
{
    public double Discount { get; set; }
    public double Price { get; set; }
    public double Quantity { get; set; }

    public int ProductId { get; set; }
    public int BillId { get; set; }

    public Bill Bill { get; set; }
    public Product Product { get; set; }
}
