using Core.Domain;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(CoincideContext context) : base(context) { }

    public async Task<IEnumerable<Account>> GetAsync(Guid userId)
    {
        return await _context.Accounts
            .Include(u => u.User)
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }
}
