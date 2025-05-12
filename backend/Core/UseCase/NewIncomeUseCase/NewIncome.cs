using Core.Commons;
using Core.Interfaces;
using Core.Mappers;
using Core.UseCase.NewIncomeUseCase.Boundaries;
using MediatR;

namespace Core.UseCase.NewIncomeUseCase;

public class NewIncome(
    IIncomeRepository incomeRepository,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<NewIncomeInput, Output>
{
    private readonly IIncomeRepository _incomeRepository = incomeRepository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Output> Handle(NewIncomeInput input, CancellationToken cancellationToken)
    {
        Output output = new();

        var user = await _userRepository.Get(input.UserId, cancellationToken);
        var income = input.MapToEntity();

        user.Balance += income.Value;
        user.TotalIncome += income.Value;

        _incomeRepository.Create(income);
        await _unitOfWork.CommitAsync(cancellationToken);

        output.AddResult(income.MapToDto(user));
        return output;
    }
}

