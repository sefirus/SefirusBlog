using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ArticleConfigurations : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .HasMany(a => a.Commits)
            .WithOne(c => c.ParentArticle)
            .HasForeignKey(c => c.ArticleId);

        builder
            .HasOne(a => a.BaseCommit)
            .WithOne(c => c.BaseArticle)
            .HasForeignKey<Article>(a => a.BaseCommitId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder
            .HasOne(a => a.PublishedCommit)
            .WithOne(c => c.PublishedArticle)
            .HasForeignKey<Article>(a => a.PublishedCommitId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder
            .Property(a => a.IsPublished)
            .HasDefaultValue(false);

        builder
            .HasOne<User>(a => a.Author)
            .WithMany(u => u.Articles)
            .HasForeignKey(a => a.AuthorId);

        builder
            .ToTable("Articles");
    }
}