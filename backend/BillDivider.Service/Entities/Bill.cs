using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillDivider.Service.Entities;

public class Bill
{
    public int Id { get; set; }
    public int PayedById { get; set; }
    public User PayedBy{ get; set; }
    public List<BillItem> BillItems { get; set; }
}
