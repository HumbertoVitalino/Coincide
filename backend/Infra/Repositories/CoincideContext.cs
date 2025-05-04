using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class CoincideContext : DbContext
{
    public CoincideContext(DbContextOptions<CoincideContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);

            entity.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            entity.HasIndex(u => u.Email)
                .IsUnique();

            entity.Property(u => u.PasswordHash)
                .IsRequired();

            entity.Property(u => u.PasswordSalt)
                .IsRequired();

            entity.Property(u => u.Birthday)
                .IsRequired();

            entity.Property(u => u.Balance)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            entity.Property(u => u.TotalIncome)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            entity.Property(u => u.TotalExpense)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);
        });
    }
}
