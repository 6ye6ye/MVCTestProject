using DomainLayer.Enums;
using DomainLayer.Models;
using DomainLayer.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnimalFinder.Data;
public class AppDbContext : IdentityDbContext<User, Role, Guid>

{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<District>()
            .HasKey(e => new { e.Id });
        modelBuilder.Entity<District>()
          .HasIndex(e => new { e.Name })
          .IsUnique(true);
        modelBuilder.Entity<District>()
            .Property(e => e.Name).HasMaxLength(100);

        modelBuilder.Entity<LostAnimal>()
            .HasOne(e => e.District)
            .WithMany(ad => ad.LostAnimals)
            .HasForeignKey(e=>e.DistrictId);

        modelBuilder.Entity<LostAnimal>()
            .HasKey(e => new { e.Id});
        modelBuilder.Entity<LostAnimal>()
              .Property(e => e.AnimalName).HasMaxLength(100);
        modelBuilder.Entity<LostAnimal>()
              .Property(e => e.Info).HasMaxLength(1000);

        var adminRole = new Role()
        {
            Id = Guid.NewGuid(),
            Name = UserRoleEnum.Admin.ToString()
        };

        var userRole = new Role()
        {
            Id = Guid.NewGuid(),
            Name = UserRoleEnum.User.ToString()
        };

        modelBuilder.Entity<Role>()
            .HasData(adminRole, userRole);
    }

    public DbSet<District> Districts { get; set; } = default!;
    public DbSet<LostAnimal> LostAnimals { get; set; } = default!;
}
