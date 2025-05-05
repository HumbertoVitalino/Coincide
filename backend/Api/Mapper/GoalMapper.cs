using Api.Models;
using Core.UseCase.NewGoalUseCase.Boundaries;

namespace Api.Mapper;

public static class GoalMapper
{
    public static NewGoalInput MapToInput(this NewGoalRequest request, Guid userId)
    {
        return new NewGoalInput(
            request.Title,
            request.TargetAmount,
            request.Description,
            request.StartDate,
            request.EndDate,
            request.MonthlyExpectedValue,
            userId);
    }
}
