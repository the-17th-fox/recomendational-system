﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillDivider.Service.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int? ProductTypeId { get; set; }

    public ProductType? ProductType { get; set; }

    public List<BillItem> BillItems { get; set; }

}
