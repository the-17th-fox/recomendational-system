using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using BillDivider.Core.Entities;

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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
