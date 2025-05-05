using Core.Commons;
using Core.Interfaces;
using Core.Mappers;
using Core.UseCase.NewGoalUseCase.Boundaries;
using MediatR;

namespace Core.UseCase.NewGoalUseCase;

public class NewGoal(
    IGoalRepository goalRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<NewGoalInput, Output>
{
    private readonly IGoalRepository _goalRepository = goalRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Output> Handle(NewGoalInput input, CancellationToken cancellationToken)
    {
        var output = new Output();

        var goal = input.MapToEntity();

        _goalRepository.Create(goal);
        await _unitOfWork.CommitAsync(cancellationToken);

        output.AddResult(goal.MapToDto());
        return output;
    }
}
