using Core.Commons;
using Core.Interfaces;
using Core.Mappers;
using Core.UseCase.GetAllIncomesUseCase.Boundaries;
using MediatR;

namespace Core.UseCase.GetAllIncomesUseCase;

public class GetAllIncomes(
    IIncomeRepository incomeRepository
) : IRequestHandler<GetAllIncomesInput, Output>
{
    private readonly IIncomeRepository _incomeRepository = incomeRepository;

    public async Task<Output> Handle(GetAllIncomesInput input, CancellationToken cancellationToken)
    {
        Output output = new();

        var incomes = await _incomeRepository.GetAll(input.UserId);

        if (incomes == null || !incomes.Any())
        {
            output.AddErrorMessage("No incomes found for the user.");
            return output;
        }

        output.AddResult(incomes.MapToDto());
        return output;
    }
}
