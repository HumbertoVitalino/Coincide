using Api.Controllers.Models;
using Core.UseCase.NewTransactionUseCase.Boundaries;

namespace Api.Mapper;

public static class NewTransactionMapper
{
    public static NewTransactionInput MapToInput(this NewTransactionRequest request, Guid userId)
    {
        return new NewTransactionInput(
            request.Value,
            request.Type,
            request.Category,
            request.Description,
            request.Date,
            request.AccountName,
            userId
        );
    }
}
