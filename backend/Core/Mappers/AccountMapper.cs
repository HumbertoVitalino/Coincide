using Core.Domain;
using Core.Dto;
using Core.UseCase.NewAccountUseCase.Boundaries;

namespace Core.Mappers;

public static class AccountMapper
{
    private const decimal DefaultValue = 0;
    public static Account MapToEntity(this NewAccountInput input)
    {
        return new Account(
            input.Name,
            DefaultValue,
            DefaultValue,
            DefaultValue,
            input.UserId
        );
    }

    public static AccountDto MapToDto(this Account account)
    {
        return new AccountDto(
            account.Name,
            account.Balance,
            account.TotalIncome,
            account.TotalExpense,
            account.User.Email
        );
    }
}
