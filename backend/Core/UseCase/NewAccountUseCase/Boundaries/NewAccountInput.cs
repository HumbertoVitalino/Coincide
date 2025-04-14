using Core.Commons;
using MediatR;

namespace Core.UseCase.NewAccountUseCase.Boundaries;

public sealed record NewAccountInput(
    string Name,
    Guid UserId
) : IRequest<Output>;
