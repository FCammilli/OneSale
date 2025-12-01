using Microsoft.EntityFrameworkCore;
using OneSale.Domain.Entities;


namespace OneSale.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Item> Items { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>().OwnsOne(i => i.Quantity, b =>
            {
                b.Property(q => q.Value).HasColumnName("Quantity");
            });

        }

    }
}
