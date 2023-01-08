using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class RoleConfigurations : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder
            .HasKey(r => r.Id);

        builder
            .Property(r => r.Name)
            .HasMaxLength(100);

        builder
            .ToTable("Roles");
    }
} 