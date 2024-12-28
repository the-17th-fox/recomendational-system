using Microsoft.AspNetCore.Identity;

namespace BillDivider.Core.Entities;

public class User : IdentityUser<int>
{
    public List<Bill> PayedBills { get; set; }
    public List<Bill> DividedBills { get; set; }
}
