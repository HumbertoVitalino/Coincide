using Core.Domain;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(CoincideContext context) : base(context) { }
    public async Task<Account> GetAsync(Guid userId, string name)
    {
        return await _context.Accounts
            .Include(u => u.User)
            .Include(t => t.Transactions)
            .Where(x => x.UserId == userId)
            .FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<IEnumerable<Account>> GetAsync(Guid userId)
    {
        return await _context.Accounts
            .Include(u => u.User)
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }
}
