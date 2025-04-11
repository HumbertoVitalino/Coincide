using Core.Commons;
using MediatR;

namespace Core.UseCase.UserRegisterUseCase.Boundaries;

public sealed record UserRegisterInput(string Name, string Email, string PasswordHash) : IRequest<Output>;
