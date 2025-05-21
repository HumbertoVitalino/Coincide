using Core.Commons;
using MediatR;

namespace Core.UseCase.GetIncomeByIdUseCase.Boundaries;

public sealed record GetIncomeByIdInput(
    Guid Id,
    Guid UserId
) :  IRequest<Output>;
