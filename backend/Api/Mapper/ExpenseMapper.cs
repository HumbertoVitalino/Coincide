using Api.Models;
using Core.UseCase.NewExpenseUseCase.Boundaries;

namespace Api.Mapper;

public static class ExpenseMapper
{
    public static NewExpenseInput MapToInput(this NewExpenseRequest request, Guid userId)
    {
        return new NewExpenseInput(
            request.Title,
            request.Value,
            request.Description,
            request.Type,
            request.Date,
            userId
        );
    }
}
