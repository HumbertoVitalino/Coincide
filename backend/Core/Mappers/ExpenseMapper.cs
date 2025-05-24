using Core.Domain;
using Core.Dto;
using Core.UseCase.NewExpenseUseCase.Boundaries;

namespace Core.Mappers;

public static class ExpenseMapper
{
    public static Expense MapToEntity(this NewExpenseInput input)
    {
        return new Expense(
            input.Title,
            input.Value,
            input.Type,
            input.Date,
            input.UserId
        );
    }

    public static ExpenseDto MapToDto(this Expense expense)
    {
        return new ExpenseDto(
            expense.Id,
            expense.Title,
            expense.Value,
            expense.Description,
            expense.Type,
            expense.Date
        );
    }
}
