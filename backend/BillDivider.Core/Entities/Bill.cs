namespace BillDivider.Core.Entities;

public class Bill : BaseEntity
{
    public int PayedById { get; set; }
    public User PayedBy { get; set; }

    public List<User> OtherMembers { get; set; }
    public List<BillItem> BillItems { get; set; }
}
