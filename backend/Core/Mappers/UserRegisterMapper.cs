using Core.Domain;
using Core.UseCase.UserRegisterUseCase.Boundaries;

namespace Core.Mappers;

public static class UserRegisterMapper
{
    public static User MapToEntity(this UserRegisterInput input)
    {
        HashPassword(input.Password, out byte[] passwordHash, out byte[] passwordSalt);

        return new User(
            input.Name,
            input.Birthday,
            input.Email,
            passwordHash,
            passwordSalt
        );
    }

    private static void HashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}


