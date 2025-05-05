using Core.Commons;
using MediatR;

namespace Core.UseCase.GetGoalsByUserUseCase.Boundaries;

public sealed record GetGoalsByUserInput(Guid Id) : IRequest<Output>;
