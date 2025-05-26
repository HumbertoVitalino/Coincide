using Core.Commons;
using Core.Interfaces;
using Core.Mappers;
using Core.UseCase.GetAllExpensesUseCase.Boundaries;
using MediatR;

namespace Core.UseCase.GetAllExpensesUseCase;

public class GetAllExpenses(
    IExpenseRepository expenseRepository    
) : IRequestHandler<GetAllExpensesInput, Output>
{
    private readonly IExpenseRepository _expenseRepository = expenseRepository;

    public async Task<Output> Handle(GetAllExpensesInput input, CancellationToken cancellationToken)
    {
        Output output = new();

        var expenses = await _expenseRepository.GetAll(input.UserId);

        if (!expenses.Any() || expenses is null)
        {
            output.AddErrorMessage("No expenses found for the user.");
            return output;
        }

        output.AddResult(expenses.MapToDto());
        return output;
    }
}
