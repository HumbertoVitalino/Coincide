using Core.Commons;
using MediatR;

namespace Core.UseCase.UserRegisterUseCase.Boundaries;

public sealed record UserRegisterInput(
    string Name,
    DateTime Birthday,
    string Email,
    string Password,
    string Confirmation
) : IRequest<Output>;
