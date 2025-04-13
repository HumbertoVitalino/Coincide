using Core.Commons;
using MediatR;

namespace Core.UseCase.UserLoginUseCase.Boundaries;

public sealed record UserLoginInput(
    string Email,
    string Password
) : IRequest<Output>;
