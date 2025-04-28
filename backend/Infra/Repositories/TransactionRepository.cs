using Core.Domain;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
{
    public TransactionRepository(CoincideContext context) : base(context) { }

    public async Task<IEnumerable<Transaction>> GetAllAsync(Guid UserId, CancellationToken cancellationToken)
    {
        return await _context.Transactions
            .Include(a => a.Account)
            .Include(u => u.User)
            .Where(u => u.UserId == UserId)
            .ToListAsync(cancellationToken);
    }
}
