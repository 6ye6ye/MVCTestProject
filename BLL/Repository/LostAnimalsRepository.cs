using System.ComponentModel;

namespace BLL.Repository;

public class LostAnimalsRepository<TContext> : BaseRepository<LostAnimal, TContext>
    where TContext : DbContext
{
    private DbSet<LostAnimal> entities;

    public LostAnimalsRepository(TContext appDbContext) : base(appDbContext)
    {
        entities = appDbContext.Set<LostAnimal>();
    }

    public override IEnumerable<LostAnimal> GetAll()
    {
        return entities.Include(e => e.District);
    }
 

    public override IEnumerable<LostAnimal> GetAll(Expression<Func<LostAnimal, bool>>? filterExpression,
    Expression<Func<LostAnimal, object>> sortExpression, ListSortDirection sortDirection, int count)
    {
        IQueryable<LostAnimal> entitiesList = entities.Include(e => e.District); // Include District entity
        entitiesList = ApplyFilterSortAndLimit(entitiesList, filterExpression, sortExpression, sortDirection, count);

        return entitiesList;
    }
}
