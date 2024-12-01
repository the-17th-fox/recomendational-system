using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BillDivider.Service.Entities;

public class BillItem
{
    public int Id { get; set; }
    public double Discount { get; set; }
    public double Price { get; set; }
    public double Amount { get; set; }

    public int ProductId { get; set; }
    public int BillId { get; set; }

    public Bill Bill { get; set; }
    public Product Product { get; set; }
}
