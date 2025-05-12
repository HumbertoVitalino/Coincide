using Core.Domain.Enums;

namespace Api.Models;

public sealed record NewIncomeRequest(
    string Title,
    decimal Value,
    string? Description,
    IncomeType Type,
    DateTime Date
);
