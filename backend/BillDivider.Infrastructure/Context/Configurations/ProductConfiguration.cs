using BillDivider.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillDivider.Infrastructure.Context.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasOne(product => product.ProductType)
           .WithMany(productType => productType.Products)
           .HasForeignKey(product => product.ProductTypeId);

        builder.Property(product => product.Name).HasMaxLength(255);
    }
}
