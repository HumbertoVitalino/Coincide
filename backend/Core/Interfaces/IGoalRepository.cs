using Core.Domain;

namespace Core.Interfaces;

public interface IGoalRepository : IBaseRepository<Goal>
{
    Task<IEnumerable<Goal>> GetByUserId(Guid userId);
    Task<Goal> GetById(Guid goalId);
}
