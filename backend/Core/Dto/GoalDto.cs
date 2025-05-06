namespace Core.Dto;

public sealed record GoalDto(
    Guid Id,
    string Title,
    decimal TargetAmount,
    string? Description,
    DateTime StartDate,
    DateTime EndDate,
    decimal MonthlyExpectedValue,
    string UserEmail,
    string UserName
);
