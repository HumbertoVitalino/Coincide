using Core.Domain;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(CoincideContext context) : base(context) { }

    public async Task<Account> GetAsync(Guid userId)
    {
        return await _context.Accounts
            .Include(u => u.User)
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }
}
