namespace BillDivider.Core.Entities;

public class ProductType : BaseEntity
{
    public string Name { get; set; }
    public List<Product> Products { get; set; }
}
