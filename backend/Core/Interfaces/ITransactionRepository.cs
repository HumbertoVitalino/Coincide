using Core.Domain;

namespace Core.Interfaces;

public interface ITransactionRepository : IBaseRepository<Transaction>
{
    Task<IEnumerable<Transaction>> GetAllAsync(Guid UserId, CancellationToken cancellationToken);
}
