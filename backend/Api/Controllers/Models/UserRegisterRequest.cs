namespace Api.Controllers.Models;

public sealed record UserRegisterRequest(string Email, string Password);