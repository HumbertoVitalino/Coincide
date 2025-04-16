using Core.Boundaries.Enums;

namespace Api.Controllers.Models;

public sealed record NewTransactionRequest(
    decimal Value,
    TransactionsType Type,
    TransactionCategory Category,
    string? Description,
    DateOnly Date,
    string AccountName
);
