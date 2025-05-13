using Core.Domain;

namespace Core.Interfaces;

public interface IIncomeRepository : IBaseRepository<Income>
{
    Task<IEnumerable<Income>> GetAll(Guid UserId);
}
