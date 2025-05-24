using Core.Commons;
using Core.Interfaces;
using Core.Mappers;
using Core.UseCase.NewExpenseUseCase.Boundaries;
using MediatR;

namespace Core.UseCase.NewExpenseUseCase;

public class NewExpense(
    IExpenseRepository expenseRepository,
    IUnitOfWork unitOfWork,
    IUserRepository userRepository
) : IRequestHandler<NewExpenseInput, Output>
{
    private readonly IExpenseRepository _expenseRepository = expenseRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<Output> Handle(NewExpenseInput input, CancellationToken cancellationToken)
    {
        Output output = new();

        var user = await _userRepository.Get(input.UserId, cancellationToken);
        var expense = input.MapToEntity();

        user.Balance -= expense.Value;
        user.TotalExpense -= expense.Value;

        _expenseRepository.Create(expense);
        await _unitOfWork.CommitAsync(cancellationToken);

        output.AddResult(expense.MapToDto());
        return output;
    }
}
