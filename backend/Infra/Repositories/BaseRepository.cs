using Core.Domain;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : Entity
{
    protected readonly CoincideContext _context;

    public BaseRepository(CoincideContext context)
    {
        _context = context;
    }

    public void Create(T entity)
    {
        entity.CreatedAt = DateTime.Now;
        _context.Add(entity);
    }
    public void Update(T entity)
    {
        entity.UpdatedAt = DateTime.Now;
        _context.Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
    }

    public async Task<T> Get(Guid? id, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }

}
