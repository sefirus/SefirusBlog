using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public static class DataSeeder
{
    public static void SeedRoles(this ModelBuilder modelBuilder)
    {
        var roles = new Role[]
        {
            new Role() { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "SuperAdmin".ToUpper() },
            new Role() { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "PowerUser".ToUpper() },
            new Role() { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "User".ToUpper() }
        };
        
        modelBuilder
            .Entity<Role>()
            .HasData(roles);
    }
}