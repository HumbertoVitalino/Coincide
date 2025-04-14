using Core.Domain;
using Core.UseCase.NewAccountUseCase.Boundaries;

namespace Core.Mappers;

public static class NewAccountMapper
{
    private const decimal DefaultValue = 0;
    public static Account MapToEntity(this NewAccountInput input)
    {
        return new Account(
            input.Name,
            DefaultValue,
            input.UserId
        );
    }
}
