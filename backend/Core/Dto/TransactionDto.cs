using Core.Boundaries.Enums;

namespace Core.Dto;

public sealed record TransactionDto(
    decimal Value,
    TransactionsType Type,
    TransactionCategory Category,
    string? Description,
    DateOnly Date,
    string Account,
    string Email
);
