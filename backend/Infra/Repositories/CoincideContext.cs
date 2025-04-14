using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class CoincideContext : DbContext
{
    public CoincideContext(DbContextOptions<CoincideContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Account> Accounts { get; set; }

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

            entity.HasMany(u => u.Accounts)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(a => a.Id);

            entity.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(a => a.Balance)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            entity.Property(a => a.CreatedAt)
                .IsRequired();

            entity.Property(a => a.UpdatedAt)
                .IsRequired();

            entity.HasOne(a => a.User)
                .WithMany(u => u.Accounts)
                .HasForeignKey(a => a.UserId)
                .IsRequired();
        });

        modelBuilder.Entity<Entity>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.Property(e => e.CreatedAt)
                .IsRequired();
        });
    }

}
