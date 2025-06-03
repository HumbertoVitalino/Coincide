using Core.Domain;

namespace Core.Interfaces;

public interface IExpenseRepository : IBaseRepository<Expense>
{
    Task<IEnumerable<Expense>> GetAll(Guid UserId);
    Task<Expense> GetAsync(Guid id);
}
