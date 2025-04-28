using Core.Domain;

namespace Core.Interfaces;

public interface IAccountRepository : IBaseRepository<Account>
{
    Task<Account> GetAsync(Guid userId, string name);
    Task<IEnumerable<Account>> GetAsync(Guid userId);
}
