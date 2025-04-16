using Api.Controllers.Models;
using Core.UseCase.NewAccountUseCase.Boundaries;

namespace Api.Mapper;

public static class NewAccountMapper
{
    public static NewAccountInput MapToInput(this NewAccountRequest request, Guid userId)
    {
        return new NewAccountInput(
            request.Name,
            userId
        );
    }
}
