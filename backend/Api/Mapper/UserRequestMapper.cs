using Api.Models;
using Core.UseCase.UserLoginUseCase.Boundaries;
using Core.UseCase.UserRegisterUseCase.Boundaries;

namespace Api.Mapper;

public static class UserRequestMapper
{
    public static UserRegisterInput MapToInput(this UserRegisterRequest request)
    {
        return new UserRegisterInput(
            request.Name,
            request.Birthday,
            request.Email,
            request.Password,
            request.ConfirmationPassword
        );
    }

    public static UserLoginInput MapToInput(this UserLoginRequest request)
    {
        return new UserLoginInput(
            request.Email,
            request.Password
        );
    }
}
