using Core.Commons;
using MediatR;

namespace Core.UseCase.GetAllExpensesUseCase.Boundaries;

public sealed record GetAllExpensesInput(
    Guid UserId
) : IRequest<Output>;
