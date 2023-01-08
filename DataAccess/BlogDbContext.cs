using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class BlogDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    
    public BlogDbContext(DbContextOptions<BlogDbContext> options) 
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
            
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}