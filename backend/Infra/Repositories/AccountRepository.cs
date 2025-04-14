using Core.Domain;
using Core.Interfaces;

namespace Infra.Repositories;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(CoincideContext context) : base(context) { }
}
