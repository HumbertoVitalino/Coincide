namespace Api.Controllers.Models;

public sealed record UserRegisterRequest(
    string Name,
    string Email,
    string Password,
    string ConfirmationPassword
);