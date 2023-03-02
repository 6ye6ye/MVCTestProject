using System.ComponentModel;

namespace BLL.Repository;

public interface IRepository<TEntity> where TEntity : class, IBaseEntity
{
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filterExpression);
    IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? filterExpression,
        Expression<Func<TEntity, object>> sortExpression, ListSortDirection sortDirection, int count);

    TEntity? GetById(Guid id);
    Task<TEntity?> GetByIdAsync(Guid id);
    
    void Create(TEntity item);
    void Update(TEntity item);
    void Delete(Guid id);
 
    TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> expression);
    Task<TEntity>? FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
    bool Any(Expression<Func<TEntity, bool>> expression);
}