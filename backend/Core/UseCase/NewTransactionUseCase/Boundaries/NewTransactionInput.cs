using Core.Boundaries.Enums;
using Core.Commons;
using MediatR;

namespace Core.UseCase.NewTransactionUseCase.Boundaries;

public sealed record NewTransactionInput(
    decimal Value,
    TransactionsType Type,
    TransactionCategory Category,
    string? Description,
    DateTime Date,
    string AccountName,
    Guid UserId
) : IRequest<Output>;
