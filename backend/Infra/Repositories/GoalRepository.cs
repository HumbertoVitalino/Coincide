using Core.Domain;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class GoalRepository : BaseRepository<Goal>, IGoalRepository
{
    public GoalRepository(CoincideContext context) : base(context)
    {
    }

    public async Task<Goal> GetById(Guid goalId)
    {
        return await _context.Goals
            .Include(t => t.User)
            .FirstOrDefaultAsync(t => t.Id == goalId);
    }

    public async Task<IEnumerable<Goal>> GetByUserId(Guid userId)
    {
        return await _context.Goals
            .Include(t => t.User)
            .Where(t => t.User.Id == userId)
            .ToListAsync();
    }
}
