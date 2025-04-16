using Core.Domain;

namespace Core.Interfaces;

public interface IAccountRepository : IBaseRepository<Account>
{
    Task<IEnumerable<Account>> GetAsync(Guid userId);
}
