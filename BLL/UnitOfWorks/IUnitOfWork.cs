namespace BLL.UnitOfWorks;

public interface IUnitOfWork : IDisposable
{
    int SaveChanges();
    IRepository<TEntity> Repository<TEntity>() where TEntity : class, IBaseEntity, new();
    Task<int> SaveChangesAsync();
    public IRepository<District> Districts { get; }
    public IRepository<LostAnimal> LostAnimals { get; }
    public IRepository<User> Users { get; }
}