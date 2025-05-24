using Core.Commons;
using Core.Domain.Enums;
using MediatR;

namespace Core.UseCase.NewExpenseUseCase.Boundaries;

public sealed record NewExpenseInput(
    string Title,
    decimal Value,
    string? Description,
    ExpenseType Type,
    DateTime Date,
    Guid UserId
) : IRequest<Output>;
