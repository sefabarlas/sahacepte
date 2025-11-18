using System.Linq.Expressions;
using SahaCepteApp.Domain.Entities;

namespace SahaCepteApp.Application.Interfaces.Persistence.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id);

    Task<IEnumerable<T>> GetAllAsync();

    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    Task AddAsync(T entity);

    void Update(T entity);
    
    void Delete(T entity);
}