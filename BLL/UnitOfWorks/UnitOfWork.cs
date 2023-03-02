namespace BLL.UnitOfWorks;

public class UnitOfWork <TContext>: IUnitOfWork, IDisposable
    where TContext : DbContext
{
    private readonly TContext _context;
    public TContext DbContext => _context;

    private Hashtable _repositories;

    private IRepository<LostAnimal> lostAnimalRepository;
    private IRepository<District> districtsRepository;
    private IRepository<User> usersRepository;

    public UnitOfWork(TContext context) 
    {
        _context = context;
    }

    public IRepository<LostAnimal> LostAnimals
    {
        get
        {
            if (lostAnimalRepository == null)
                lostAnimalRepository = new LostAnimalsRepository<TContext>(_context);
            return lostAnimalRepository;
        }
    }

    public IRepository<District> Districts
    {
        get
        {
            if (districtsRepository == null)
                districtsRepository = new DistrictsRepository<TContext>(_context);
            return districtsRepository;
        }
    }

    public IRepository<User> Users
    {
        get
        {
            if (usersRepository == null)
                usersRepository = new UsersRepository<TContext>(_context);
            return usersRepository;
        }
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public IRepository<TEntity> Repository<TEntity>() where TEntity : class, IBaseEntity, new()
    {
        if (_repositories == null) _repositories = new Hashtable();

        var type = typeof(TEntity).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(BaseRepository<TEntity, TContext>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

            _repositories.Add(type, repositoryInstance);
        }

        return (IRepository<TEntity>)_repositories[type];
    }


    //disposes current object
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    //disposes all external resources
    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
