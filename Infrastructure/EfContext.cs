
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class EfContext : DbContext
    {

        public EfContext(DbContextOptions<EfContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.User)
                .WithMany(u => u.Products)
                .HasForeignKey(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasIndex(p => new { p.ManufactureEmail, p.ProduceDate })
                .IsUnique();


            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.FirstName).HasMaxLength(50);
                entity.Property(u => u.LastName).HasMaxLength(50);
                entity.Property(u => u.Username).HasMaxLength(30);
                entity.Property(u => u.Password).HasMaxLength(30);
                entity.Property(u => u.Email).HasMaxLength(50);
                entity.Property(u => u.PhoneNumber).HasMaxLength(20);
            });
        }

    }
}
