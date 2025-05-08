using Core.Commons;
using MediatR;

namespace Core.UseCase.GetGoalByIdUseCase.Boundaries;

public sealed record GetGoalByIdInput(
    Guid Id,
    Guid UserId
) : IRequest<Output>;
