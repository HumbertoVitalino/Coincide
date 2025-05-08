namespace Api.Models;

public sealed record NewGoalRequest(
    string Title,
    decimal TargetAmount,
    string? Description,
    DateTime StartDate,
    DateTime EndDate,
    decimal MonthlyExpectedValue
);
