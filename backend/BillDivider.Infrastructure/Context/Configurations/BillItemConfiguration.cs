using BillDivider.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillDivider.Infrastructure.Context.Configurations;

public class BillItemConfiguration : IEntityTypeConfiguration<BillItem>
{
    public void Configure(EntityTypeBuilder<BillItem> builder)
    {
        builder.HasOne(billItem => billItem.Bill)
            .WithMany(bill => bill.BillItems)
            .HasForeignKey(billItem => billItem.BillId);

        builder.HasOne(billItem => billItem.Product)
            .WithMany(product => product.BillItems)
            .HasForeignKey(billItem => billItem.ProductId);
    }
}
