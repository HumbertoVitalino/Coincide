using Core.Domain;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class ExpenseRepository : BaseRepository<Expense>, IExpenseRepository
{
    public ExpenseRepository(CoincideContext context) : base(context) { }

    public async Task<IEnumerable<Expense>> GetAll(Guid UserId)
    {
        return await _context.Expenses
            .Include(x => x.User)
            .Where(x => x.UserId == UserId)
            .ToListAsync();
    }

    public async Task<Expense> GetAsync(Guid id)
    {
        return await _context.Expenses
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
