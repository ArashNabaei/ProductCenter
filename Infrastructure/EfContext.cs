
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
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.FirstName).HasMaxLength(50);
                entity.Property(u => u.LastName).HasMaxLength(50);
                entity.Property(u => u.Username).HasMaxLength(30).IsRequired();
                entity.Property(u => u.Password).HasMaxLength(30).IsRequired();
                entity.Property(u => u.Email).HasMaxLength(50);
                entity.Property(u => u.PhoneNumber).HasMaxLength(20);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Name).HasMaxLength(50).IsRequired();
                entity.Property(p => p.ManufacturePhone).HasMaxLength(20);
                entity.Property(p => p.ManufactureEmail).HasMaxLength(50);
                entity.Property(p => p.UserId).IsRequired();

                entity.HasIndex(p => new { p.ManufactureEmail, p.ProduceDate })
                      .IsUnique();
            });
        }

    }
}
