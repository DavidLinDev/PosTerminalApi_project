using Microsoft.EntityFrameworkCore;
using CoreLayer.Models;
using DataLayer.Configurations;

namespace DataLayer
{
    public class TerminalDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public TerminalDbContext(DbContextOptions<TerminalDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new ProductConfiguration());

            builder
                .ApplyConfiguration(new OrderConfiguration());
        }
    }
}
