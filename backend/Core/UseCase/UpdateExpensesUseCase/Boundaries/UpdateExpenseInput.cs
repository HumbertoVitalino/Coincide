using Core.Commons;
using Core.Domain.Enums;
using MediatR;

namespace Core.UseCase.UpdateExpensesUseCase.Boundaries;

public sealed record  UpdateExpenseInput(
    Guid Id,
    string Title,
    decimal Value,
    string? Description,
    ExpenseType Type,
    DateTime Date,
    Guid UserId
) : IRequest<Output>;
