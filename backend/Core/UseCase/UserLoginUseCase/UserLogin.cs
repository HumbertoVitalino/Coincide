using Core.Commons;
using Core.Interfaces;
using Core.UseCase.UserLoginUseCase.Boundaries;
using MediatR;

namespace Core.UseCase.UserLoginUseCase;

public class UserLogin(
    IUserRepository userRepository,
    IJwtTokenProvider jwtToken
) : IRequestHandler<UserLoginInput, Output>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtTokenProvider _jwtToken = jwtToken;

    public async Task<Output> Handle(UserLoginInput input, CancellationToken cancellationToken)
    {
        Output output = new();

        var user = await _userRepository.GetByEmailAsync(input.Email);

        if (user == null)
        {
            output.AddErrorMessage("No user found for this email");
            return output;
        }

        using (var hmac = new System.Security.Cryptography.HMACSHA512(user.PasswordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input.Password));
            if (!computedHash.SequenceEqual(user.PasswordHash))
            {
                output.AddErrorMessage("Wrong password");
                return output;
            }
        }

        var token = _jwtToken.GenerateToken(user.Id, user.Email);

        output.AddResult(token);
        return output;
    }
}
