using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillDivider.Service.Entities;
using Microsoft.EntityFrameworkCore;

namespace BillDivider.Infrastructure.Context;

public class BillDividerContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    public DbSet<User> Users {  get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<BillItem> BillItems { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }

    public BillDividerContext(DbContextOptions<BillDividerContext> options) : base(options)
    {
        if (Database.GetPendingMigrations().Any())
        {
            Database.EnsureCreated();
        }
    }

}
