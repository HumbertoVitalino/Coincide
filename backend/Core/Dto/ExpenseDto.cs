using Core.Domain.Enums;

namespace Core.Dto;

public record ExpenseDto(
    Guid Id,
    string Title,
    decimal Value,
    string? Description,
    ExpenseType Type,
    DateTime Date
);