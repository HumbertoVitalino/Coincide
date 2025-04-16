using Core.Domain;
using Core.Interfaces;

namespace Infra.Repositories;

public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
{
    public TransactionRepository(CoincideContext context) : base(context) { }
}
