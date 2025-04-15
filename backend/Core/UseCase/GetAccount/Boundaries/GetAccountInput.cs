using Core.Commons;
using MediatR;

namespace Core.UseCase.GetAccount.Boundaries;

public sealed record GetAccountInput(Guid Id) : IRequest<Output>;
