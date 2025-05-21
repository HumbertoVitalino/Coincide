using Core.Commons;
using Core.Interfaces;
using Core.Mappers;
using Core.UseCase.GetIncomeByIdUseCase.Boundaries;
using MediatR;

namespace Core.UseCase.GetIncomeByIdUseCase;

public class GetIncomeById(
    IIncomeRepository incomeRepository
) : IRequestHandler<GetIncomeByIdInput, Output>
{
    private readonly IIncomeRepository _incomeRepository = incomeRepository;

    public async Task<Output> Handle(GetIncomeByIdInput input, CancellationToken cancellationToken)
    {
        Output output = new();

        var income = await _incomeRepository.GetAsync(input.Id);

        if (income == null)
        {
            output.AddErrorMessage("Income not found.");
            return output;
        }

        if (input.UserId != income.UserId)
        {
            output.AddErrorMessage("You do not have permission to access this income.");
            return output;
        }

        output.AddResult(income.MapToDto(income.User));
        return output;
    }
}
