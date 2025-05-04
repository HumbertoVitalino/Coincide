using Core.Commons;
using Core.Interfaces;
using Core.Mappers;
using Core.UseCase.UserRegisterUseCase.Boundaries;
using MediatR;

namespace Core.UseCase.UserRegisterUseCase;

public class UserRegister(IUserRepository userRepository, IUnitOfWork unitOfWork) : IRequestHandler<UserRegisterInput, Output>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Output> Handle(UserRegisterInput input, CancellationToken cancellationToken)
    {
        var output = new Output();

        var existingUser = await _userRepository.GetByEmailAsync(input.Email);

        if (existingUser != null)
        {
            output.AddErrorMessage("User already exists!");
            return output;
        }

        if (input.Password != input.Confirmation)
        {
            output.AddErrorMessage("Passwords are different!");
            return output;
        }

        var user = input.MapToEntity();

        _userRepository.Create(user);
        await _unitOfWork.CommitAsync(cancellationToken);

        output.AddResult(input);
        return output;
    }    
}
