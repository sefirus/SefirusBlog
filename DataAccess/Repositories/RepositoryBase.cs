using System.Linq.Expressions;
using Core.Exceptions;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DataAccess.Repositories;

public class RepositoryBase<T> : IRepository<T> 
    where T : class, ICreatableEntity
{
    private readonly BlogDbContext _context;
    protected readonly DbSet<T> DbSet;

    public RepositoryBase(BlogDbContext context)
    {
        _context = context;
        DbSet = _context.Set<T>();
    }

    public IQueryable<T> GetQuery(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        int? take = null, int? skip = null,
        bool asNoTracking = false)
    {
        var query = DbSet.AsQueryable();

        if (asNoTracking)
            query = query.AsNoTracking();
        
        if (include is not null)
            query = include(query);
        
        if (filter is not null)
            query = query.Where(filter);
        
        if (orderBy is not null)
            query = orderBy(query);
        
        if(skip is not null)
            query = query.Skip(skip.Value);

        if (take is not null)
            query = query.Take(take.Value);          
        
        return query;
    }

    public async Task<IList<T>> QueryAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        int? take = null, int? skip = null,
        bool asNoTracking = false)
    {
        var query = GetQuery(filter, orderBy, include, take, skip, asNoTracking);
        
        return await query.ToListAsync();
    }

    public async Task<T?> GetFirstOrDefaultAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool asNoTracking = false)
    {
        var query = await QueryAsync(
            filter: filter,
            include: include,
            asNoTracking: asNoTracking
            );
        
        return query.FirstOrDefault();
    }

    public async Task<T> GetFirstAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool asNoTracking = false)
    {
        var entity = await GetFirstOrDefaultAsync(filter: filter, include: include, asNoTracking: asNoTracking);
        if (entity is null)
        {
            throw new NotFoundException($"Wanted {typeof(T).Name} does not exist");
        }

        return entity;
    }

    public void Delete(T entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _context.Attach(entity);
        }
        
        _context.Entry(entity).State = EntityState.Deleted;
    }

    public async Task InsertAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public async Task SaveChangesAsync()
    {
        _context.ChangeTracker
            .Entries()
            .Where(e => e.Entity is ICreatableEntity
                && e.State == EntityState.Added)
            .ToList()
            .ForEach(e =>
            {
                var entity = (ICreatableEntity)e.Entity;
                if (entity.Id == Guid.Empty)
                {
                    entity.Id = Guid.NewGuid();
                }
                entity.CreatedDate = DateTime.UtcNow;
            });
        
        await _context.SaveChangesAsync();
    }
}