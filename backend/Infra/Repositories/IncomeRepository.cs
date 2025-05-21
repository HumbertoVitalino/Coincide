using Core.Domain;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class IncomeRepository : BaseRepository<Income>, IIncomeRepository
{
    public IncomeRepository(CoincideContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Income>> GetAll(Guid UserId)
    {
        return await _context.Incomes
            .Include(x => x.User)
            .Where(x => x.UserId == UserId)
            .ToListAsync();
    }

    public async Task<Income> GetAsync(Guid id)
    {
        return await _context.Incomes
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
