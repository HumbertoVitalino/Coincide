using Core.Commons;
using Core.Domain.Enums;
using MediatR;

namespace Core.UseCase.NewIncomeUseCase.Boundaries;

public sealed record NewIncomeInput(
    string Title,
    decimal Value,
    string? Description,
    IncomeType Type,
    DateTime Date,
    Guid UserId
) : IRequest<Output>;
