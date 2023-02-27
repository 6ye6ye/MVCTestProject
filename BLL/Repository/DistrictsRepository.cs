namespace BLL.Repository;

public class DistrictsRepository<TContext> : BaseRepository<District, TContext>
    where TContext : DbContext
{
    private readonly TContext _context;
    private DbSet<District> entities;

    public DistrictsRepository(TContext appDbContext) : base(appDbContext)
    {
        _context = appDbContext;
        entities = appDbContext.Set<District>();
    }
}
