using BillDivider.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillDivider.Infrastructure.Context.Configurations;

public class BillConfiguration : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        builder.HasOne(bill => bill.PayedBy)
                .WithMany(user => user.PayedBills)
                .HasForeignKey(bill => bill.PayedById)
                .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(bill => bill.OtherMembers)
                .WithMany(user => user.DividedBills);
    }
}