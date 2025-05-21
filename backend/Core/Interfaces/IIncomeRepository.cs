using Core.Domain;

namespace Core.Interfaces;

public interface IIncomeRepository : IBaseRepository<Income>
{
    Task<IEnumerable<Income>> GetAll(Guid UserId);
    Task<Income> GetAsync(Guid id);
}
