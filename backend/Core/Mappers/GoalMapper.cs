using Core.Domain;
using Core.Dto;
using Core.UseCase.NewGoalUseCase.Boundaries;

namespace Core.Mappers;

public static class GoalMapper
{
    public static Goal MapToEntity(this NewGoalInput input)
    {
        return new Goal(
            input.Title,
            input.TargetAmount,
            input.Description,
            input.StartDate,
            input.EndDate,
            input.MonthlyExpectedValue,
            input.userId
        );
    }

    public static GoalDto MapToDto(this Goal goal)
    {
        return new GoalDto(
            goal.Id,
            goal.Title,
            goal.TargetAmount,
            goal.Description,
            goal.StartDate,
            goal.EndDate,
            goal.MonthlyExpectedValue
        );
    }
}
