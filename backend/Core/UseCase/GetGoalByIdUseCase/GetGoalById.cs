using Core.Commons;
using Core.Interfaces;
using Core.Mappers;
using Core.UseCase.GetGoalByIdUseCase.Boundaries;
using MediatR;

namespace Core.UseCase.GetGoalByIdUseCase;

public class GetGoalById(
    IGoalRepository goalRepository
) : IRequestHandler<GetGoalByIdInput, Output>
{
    private readonly IGoalRepository _goalRepository = goalRepository;

    public async Task<Output> Handle(GetGoalByIdInput input, CancellationToken cancellationToken)
    {
        Output output = new();
        var goal = await _goalRepository.GetById(input.Id);

        if (goal == null)
        {
            output.AddErrorMessage("Goal not found");
            return output;
        }

        if (goal.UserId != input.UserId)
        {
            output.AddErrorMessage("User not authorized to access this goal");
            return output;
        }

        output.AddResult(goal.MapToDto());
        return output;
    }
}
