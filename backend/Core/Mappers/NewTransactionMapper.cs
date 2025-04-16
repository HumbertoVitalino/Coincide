using Core.Domain;
using Core.Dto;
using Core.UseCase.NewTransactionUseCase.Boundaries;

namespace Core.Mappers;

public static class NewTransactionMapper
{
    public static Transaction MapToEntity(this NewTransactionInput input, Account account)
    {
        return new Transaction(
            input.Value,
            input.Description,
            input.Type,
            input.Category,
            input.Date,
            account.Id,
            input.UserId
        );
    }

    public static TransactionDto MapToDto(this Transaction transaction)
    {
        return new TransactionDto(
            transaction.Value,
            transaction.Type,
            transaction.Category,
            transaction.Description,
            transaction.Date,
            transaction.Account.Name,
            transaction.User.Email
        );
    }
}
