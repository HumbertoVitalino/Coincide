using Core.Domain.Enums;

namespace Api.Models;

public sealed record NewExpenseRequest(
    string Title,
    decimal Value,
    string? Description,
    ExpenseType Type,
    DateTime Date
);
