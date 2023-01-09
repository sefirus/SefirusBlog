using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class CommitConfiguration : IEntityTypeConfiguration<Commit>
{
    public void Configure(EntityTypeBuilder<Commit> builder)
    {
        builder
            .HasKey(c => c.Id);
        
        builder
            .HasOne<Commit>(c => c.Parent)
            .WithMany(c => c.Children)
            .HasForeignKey(c => c.ParentId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .Property(c => c.Title)
            .HasMaxLength(1000);

        builder
            .Property(c => c.Body)
            .HasMaxLength(15000);

        builder
            .ToTable("Commits");
    }
}