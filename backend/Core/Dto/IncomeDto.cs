using Core.Domain.Enums;

namespace Core.Dto;

public record IncomeDto(
    Guid Id,
    string Title,
    decimal Value,
    string? Description,
    IncomeType Type,
    DateTime Date,
    decimal UserBalance,
    decimal UserTotalIncome
);