using Core.Commons;
using MediatR;

namespace Core.UseCase.GetTransactions.Boundaries;

public sealed record GetTransactionsInput(Guid UserId) : IRequest<Output>;
