namespace Api.Controllers.Models;

public sealed record UserRegisterRequest(
    string Name,
    DateTime Birthday,
    string Email,
    string Password,
    string ConfirmationPassword
);