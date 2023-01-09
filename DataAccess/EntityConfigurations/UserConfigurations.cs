using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(u => u.Id);
        
        builder
            .Property(u => u.Email)
            .HasMaxLength(500);

        builder
            .Property(u => u.Nickname)
            .HasMaxLength(500);

        builder
            .Property(u => u.IsActive)
            .HasDefaultValue(true);

        builder
            .HasOne<Role>(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);

        builder
            .ToTable("Users");
    }
}