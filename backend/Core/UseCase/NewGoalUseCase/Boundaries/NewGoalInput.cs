using Core.Commons;
using MediatR;

namespace Core.UseCase.NewGoalUseCase.Boundaries;

public sealed record NewGoalInput(
    string Title,
    decimal TargetAmount,
    string? Description,
    DateTime StartDate,
    DateTime EndDate,
    decimal MonthlyExpectedValue,
    Guid userId
) : IRequest<Output>;
