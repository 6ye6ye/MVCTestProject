namespace BLL.Repository;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> GetAll (Expression<Func<TEntity, bool>> filterExpression);
    TEntity? GetById(Guid id);
    void Create(TEntity item);
    void Update(TEntity item);
    void Delete(Guid id);

    Task<TEntity?> GetByIdAsync(Guid id);
    TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> expression);
    Task<TEntity>? FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
    bool Any(Expression<Func<TEntity, bool>> expression);
}