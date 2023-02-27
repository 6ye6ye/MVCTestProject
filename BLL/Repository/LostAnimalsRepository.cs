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
}
