using Core.Commons;
using Core.Interfaces;
using Core.Mappers;
using Core.UseCase.GetGoalsByUserUseCase.Boundaries;
using MediatR;

namespace Core.UseCase.GetGoalsByUserUseCase;

public class GetGoalsByUser(
    IGoalRepository goalRepository
) : IRequestHandler<GetGoalsByUserInput, Output>
{
    private readonly IGoalRepository _goalRepository = goalRepository;

    public async Task<Output> Handle(GetGoalsByUserInput input, CancellationToken cancellationToken)
    {
        var output = new Output();

        var goals = await _goalRepository.GetByUserId(input.Id);

        if (!goals.Any())
        {
            output.AddErrorMessage("No goals found for the user.");
            return output;
        }

        output.AddResult(goals.MapToDto());
        return output;
    }
}
