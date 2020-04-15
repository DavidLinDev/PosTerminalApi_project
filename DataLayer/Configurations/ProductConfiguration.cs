using CoreLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .IsRequired();

            builder
                .Property(m => m.CodeName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.UnitPrice)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder
                .Property(m => m.UnitDiscount)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder
                .Property(m => m.DiscountQtyBase)
                .IsRequired();

            builder
                .ToTable("Products");
        }
    }
}
