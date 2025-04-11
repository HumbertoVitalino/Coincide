namespace Core.Domain;

public sealed record User
(
    Guid Id,
    string Email,
    string PasswordHash
);
