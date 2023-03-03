using DomainLayer.Enums;
using DomainLayer.Models;
using DomainLayer.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnimalFinder.Data;
public class AppDbContext : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>, IdentityUserRole<Guid>, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>

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
            .HasForeignKey(e => e.DistrictId);

        modelBuilder.Entity<LostAnimal>()
            .HasKey(e => new { e.Id });
        modelBuilder.Entity<LostAnimal>()
         .HasOne(e => e.Creator)
         .WithMany(e => e.LostAnimalRecords)
         .HasForeignKey(e => e.CreatorId)
         .OnDelete(DeleteBehavior.Cascade);

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

        var userAdmin = new User()
        {
            Id = Guid.NewGuid(),
            Email = "admin@gmail.com",
            PasswordHash = "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==",
            UserName = "admin",
            NormalizedEmail = "admin@gmail.com".Normalize(),
            NormalizedUserName = "admin".Normalize(),
            SecurityStamp = Guid.NewGuid().ToString()
        };

        var userRole1 = new IdentityUserRole<Guid>()
        {
            RoleId = adminRole.Id,
            UserId = userAdmin.Id
        };

        modelBuilder.Entity<Role>()
            .HasData(adminRole, userRole);
        modelBuilder.Entity<User>()
            .HasData(userAdmin);
        modelBuilder.Entity<IdentityUserRole<Guid>>()
           .HasData(userRole1);
    }

    public DbSet<District> Districts { get; set; } = default!;
    public DbSet<LostAnimal> LostAnimals { get; set; } = default!;
}
