using Api.Controllers.Models;
using Core.UseCase.UserRegisterUseCase.Boundaries;

namespace Api.Mapper;

public static class UserRequestMapper
{
    public static UserRegisterInput MapToInput(this UserRegisterRequest request)
    {
        return new UserRegisterInput(
            request.Name,
            request.Email,
            request.Password,
            request.ConfirmationPassword
        );
    }
}
