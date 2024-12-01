using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillDivider.Service.Entities;

public class User : IdentityUser<int>
{
    public List<Bill> Bills { get; set; }

}
