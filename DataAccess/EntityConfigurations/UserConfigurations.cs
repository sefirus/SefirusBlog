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
            .Property(u => u.FirstName)
            .HasMaxLength(500);

        builder
            .Property(u => u.LastName)
            .HasMaxLength(500);

        builder
            .HasOne<Role>(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);

        builder
            .ToTable("Users");
    }
}