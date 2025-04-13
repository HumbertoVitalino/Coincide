using Core.Domain;

namespace Core.Interfaces;

public interface IBaseRepository<T> where T : Entity
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T> Get(Guid? id, CancellationToken cancellationToken);
    Task<List<T>> GetAll(CancellationToken cancellationToken);
}
