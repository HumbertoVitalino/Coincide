using Core.Commons;
using Core.Interfaces;
using Core.Mappers;
using Core.UseCase.UpdateExpensesUseCase.Boundaries;
using MediatR;

namespace Core.UseCase.UpdateExpensesUseCase;

public class UpdateExpense(
    IExpenseRepository expenseRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<UpdateExpenseInput, Output>
{
    private readonly IExpenseRepository _expenseRepository = expenseRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Output> Handle(UpdateExpenseInput request, CancellationToken cancellationToken)
    {
        Output output = new();

        var expense = await _expenseRepository.GetAsync(request.Id);

        if (expense is null || expense.UserId != request.UserId)
        {
            output.AddErrorMessage("Expense not found.");
            return output;
        }

        expense.Title = request.Title;
        expense.Value = request.Value;
        expense.Description = request.Description;
        expense.Type = request.Type;
        expense.Date = request.Date;

        _expenseRepository.Update(expense);
        await _unitOfWork.CommitAsync(cancellationToken);

        output.AddResult(expense.MapToDto());
        return output;
    }
}
