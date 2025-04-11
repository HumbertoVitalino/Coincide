using Core.Interfaces;

namespace Infra.Repositories;

public class UnitOfWork(CoincideContext context) : IUnitOfWork
{
    private readonly CoincideContext _context = context;

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
