using System.ComponentModel;
using System.Linq;

namespace BLL.Repository;

public abstract class BaseRepository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : class, IBaseEntity
    where TContext : DbContext
{
    private readonly TContext _context;
    private DbSet<TEntity> entities;

    public BaseRepository(TContext appDbContext)
    {
        _context = appDbContext;
        entities = appDbContext.Set<TEntity>();
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        return entities;
    }

    public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filterExpression)
    {
        return entities.Where(filterExpression);
    }

    public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? filterExpression,
        Expression<Func<TEntity, object>> sortExpression, ListSortDirection sortDirection, int count)
    {
        return ApplyFilterSortAndLimit(entities, filterExpression, sortExpression, sortDirection, count);
    }

    private protected IQueryable<TEntity> ApplyFilterSortAndLimit(IQueryable<TEntity> entitiesList, Expression<Func<TEntity, bool>>? filterExpression,
    Expression<Func<TEntity, object>> sortExpression, ListSortDirection sortDirection, int count)
    {
        if (filterExpression != null)
            entitiesList = entitiesList.Where(filterExpression);

        switch (sortDirection)
        {
            case ListSortDirection.Ascending:
                entitiesList = entitiesList.OrderBy(sortExpression);
                break;
            case ListSortDirection.Descending:
                entitiesList = entitiesList.OrderByDescending(sortExpression);
                break;
            default:
                throw new NotImplementedException();
        }

        entitiesList = entitiesList.Take(count);

        return entitiesList;
    }

    public TEntity? GetById(Guid id)
    {
        return entities.Find(id);
    }

    public void Create(TEntity entity)
    {
        entities.Add(entity);
    }

    public void Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(Guid id)
    {
        var entity = entities.Find(id);
        if (entity != null)
            entities.Remove(entity);
    }

    public async Task<TEntity>? GetByIdAsync(Guid id)
    {
        return await entities.FindAsync(id);
    }

    public TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> expression)
    {
        return entities.FirstOrDefault(expression);
    }

    public async Task<TEntity>? FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await entities.FirstOrDefaultAsync(expression);
    }

    public bool Any(Expression<Func<TEntity, bool>> expression)
    {
        return entities.Any(expression);
    }
}
