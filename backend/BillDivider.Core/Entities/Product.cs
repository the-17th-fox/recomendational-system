namespace BillDivider.Core.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }

    public int? ProductTypeId { get; set; }

    public ProductType? ProductType { get; set; }

    public List<BillItem> BillItems { get; set; }

}
