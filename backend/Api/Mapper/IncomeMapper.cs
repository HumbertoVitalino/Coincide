using Api.Models;
using Core.UseCase.NewIncomeUseCase.Boundaries;

namespace Api.Mapper;

public static class IncomeMapper
{
    public static NewIncomeInput MapToInput(this NewIncomeRequest request, Guid userId)
    {
        return new NewIncomeInput(
            request.Title,
            request.Value,
            request.Description,
            request.Type,
            request.Date,
            userId
        );
    }
}
