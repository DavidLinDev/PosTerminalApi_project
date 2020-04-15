using CoreLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.OrderedProducts)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(m => m.Amount)
                .HasColumnType("decimal(10,2)")
                .IsRequired();
            
            builder
                .Property(m => m.Date)
                .IsRequired();

            builder
                .ToTable("Orders");
        }
    }
}
