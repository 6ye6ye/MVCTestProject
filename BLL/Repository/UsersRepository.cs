namespace BLL.Repository;

public class UsersRepository<TContext> : BaseRepository<User, TContext>
    where TContext : DbContext
{
    private DbSet<User> entities;

    public UsersRepository(TContext appDbContext) : base(appDbContext)
    {
        entities = appDbContext.Set<User>();
    }

    public async Task<User>? FirstOrDefaultAsync(Expression<Func<User, bool>> expression)
    {
        return await entities.FirstOrDefaultAsync(expression);
    }
}
