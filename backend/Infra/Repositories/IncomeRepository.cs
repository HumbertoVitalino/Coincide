using Core.Domain;
using Core.Interfaces;

namespace Infra.Repositories;

public class IncomeRepository : BaseRepository<Income>, IIncomeRepository
{
    public IncomeRepository(CoincideContext context) : base(context)
    {
    }
}
