using Core.Entities;
using Core.Enums;
using Core.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public static class DataSeeder
{
    public static void SeedRoles(this ModelBuilder modelBuilder)
    {
        var roles = new Role[]
        {
            new Role() { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = RolesEnum.SuperAdmin },
            new Role() { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = RolesEnum.PowerUser },
            new Role() { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = RolesEnum.RegularUser }
        };
        
        modelBuilder
            .Entity<Role>()
            .HasData(roles);
    }

    public static void SeedUsers(this ModelBuilder modelBuilder)
    {
        HashHelper.CreatePasswordHash("SuperAdminPassword", out var adminPasswordHash, out var  adminPasswordSalt);
        var superAdmin = new User()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            BirthDate = new DateTime(2000, 1, 1),
            CreatedAt = DateTime.Now,
            Email = "admin@email.com",
            Nickname = "Super Admin",
            RoleId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            PasswordHash = adminPasswordHash,
            PasswordSalt = adminPasswordSalt
        };  
        modelBuilder
            .Entity<User>()
            .HasData(superAdmin);
    }
}