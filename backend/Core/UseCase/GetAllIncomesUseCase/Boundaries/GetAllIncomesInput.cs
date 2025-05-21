using Core.Commons;
using MediatR;

namespace Core.UseCase.GetAllIncomesUseCase.Boundaries;

public sealed record GetAllIncomesInput(
    Guid  UserId
)  : IRequest<Output>;
